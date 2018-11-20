using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Faker
{
    public class Faker
    {
        private readonly Dictionary<Type, IBasicGenerator> BaseTypeGenerators;
        private Dictionary<Type, IPlugin> Plugins;
        private Stack<Type> ClassStack;

        public Faker()
        {
            BaseTypeGenerators = new Dictionary<Type, IBasicGenerator>();
            Plugins = new Dictionary<Type, IPlugin>();
            ClassStack = new Stack<Type>();

            ICollection<IPlugin> plugins = LoadPlugins(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\ExampleUseFaker\\Plugins");
            if (plugins != null)
            {
                foreach (var item in plugins)
                {
                    Plugins.Add(item.type, item);
                }
            }

            BaseTypeGenerators.Add(typeof(bool), new BasicBoolGenerator());
            BaseTypeGenerators.Add(typeof(double), new BasicDoubleGenerator());
            BaseTypeGenerators.Add(typeof(float), new BasicFloatGenerator());
            BaseTypeGenerators.Add(typeof(int), new BasicIntGenerator());
            BaseTypeGenerators.Add(typeof(long), new BasicLongGenerator());
            BaseTypeGenerators.Add(typeof(string), new BasicStringGenerator());
            BaseTypeGenerators.Add(typeof(char), new BasicCharGenerator());
        }

        public T Create<T>()
        {
            return (T)CreateObject(typeof(T));
        }

        private object CreateObject(Type type)
        {
            object generatedObject = null;
            Stack<string> fieldsOfConstructor = new Stack<string>();


            if (type != null)
            {
                ConstructorInfo[] constructor = type.GetConstructors();
                if (constructor.Length == 0)
                    return null;
                ParameterInfo[] constructorParameters = constructor[0].GetParameters();

                var inputParametes = new List<object>();
                foreach (ParameterInfo parameter in constructorParameters)
                {
                    if (!ClassStack.Contains(parameter.ParameterType))
                    {
                        fieldsOfConstructor.Push(parameter.Name);
                        fieldsOfConstructor.Push("_" + parameter.Name);
                        ClassStack.Push(parameter.ParameterType);
                        inputParametes.Add(GenerateValue(parameter.ParameterType));
                        ClassStack.Pop();
                    }
                    else
                    {
                        inputParametes.Add(null);
                    }
                }
                generatedObject = constructor[0].Invoke(inputParametes.ToArray());

                FieldInfo[] fields = type.GetFields();
                foreach (FieldInfo field in fields)
                {
                    if (!fieldsOfConstructor.Contains(field.Name) && !ClassStack.Contains(field.FieldType))
                    {
                        ClassStack.Push(field.FieldType);
                        field.SetValue(generatedObject, GenerateValue(field.FieldType));
                        ClassStack.Pop();
                    }
                }

            }

            return generatedObject;
        }

        private object GenerateValue(Type parameterType)
        {
            object generatedObject;
            if (BaseTypeGenerators.ContainsKey(parameterType))
            {
                generatedObject = BaseTypeGenerators[parameterType].GenerateRandomValue();
                return generatedObject;
            }
            else
                if (parameterType.IsGenericType && Plugins.ContainsKey(parameterType.GetGenericTypeDefinition()))
                {
                    IList generatedArray = (IList)Plugins[parameterType.GetGenericTypeDefinition()].GenerateRandomValue(parameterType);
                    for (int i = 0; i < 5; i++)
                    {
                        generatedArray.Add(GenerateValue(parameterType.GenericTypeArguments[0]));
                    }   

                    generatedObject = generatedArray;
                    return generatedObject;
                }
                else
                    if (Plugins.ContainsKey(parameterType))
                    {
                        generatedObject = Plugins[parameterType].GenerateRandomValue(parameterType);
                        return generatedObject;
                    }
                    else
                        if (parameterType.IsClass && !parameterType.IsArray && !parameterType.IsGenericType)
                        {
                            generatedObject = CreateObject(parameterType);
                            return generatedObject;
                        }
            return null;
        }

        private ICollection<IPlugin> LoadPlugins(string path)
        {
            string[] dllFileNames = null;

            if (Directory.Exists(path))
            {
                dllFileNames = Directory.GetFiles(path, "*.dll");

                ICollection<Assembly> assemblies = new List<Assembly>(dllFileNames.Length);
                foreach (string dllFile in dllFileNames)
                {
                    AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
                    Assembly assembly = Assembly.Load(an);
                    assemblies.Add(assembly);
                }

                Type pluginType = typeof(IPlugin);
                ICollection<Type> pluginTypes = new List<Type>();
                foreach (Assembly assembly in assemblies)
                {
                    if (assembly != null)
                    {
                        Type[] types = assembly.GetTypes();

                        foreach (Type type in types)
                        {
                            if (type.IsInterface || type.IsAbstract)
                            {
                                continue;
                            }
                            else
                            {
                                if (type.GetInterface(pluginType.FullName) != null)
                                {
                                    pluginTypes.Add(type);
                                }
                            }
                        }
                    }
                }

                ICollection<IPlugin> plugins = new List<IPlugin>(pluginTypes.Count);
                foreach (Type type in pluginTypes)
                {
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    plugins.Add(plugin);
                }

                return plugins;
            }

            return null;
        }
    }
}
