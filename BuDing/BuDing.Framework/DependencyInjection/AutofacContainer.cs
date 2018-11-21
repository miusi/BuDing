using Autofac;
using Autofac.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BuDing.Framework.Ioc
{
	class AutofacContainer
	{
		private static ContainerBuilder _builder = new ContainerBuilder();

		private static IContainer _container;

		private static string[] _otherAssembly;

		private static List<Type> _types = new List<Type>();

		private static Dictionary<Type, Type> _dicTypes = new Dictionary<Type, Type>();


		/// <summary>
		/// 注册程序集
		/// </summary>
		/// <param name="assemblies"></param>
		public static void Register(params string[] assemblies)
		{
			_otherAssembly = assemblies;
		}

		/// <summary>
		/// 注册类型
		/// </summary>
		/// <param name="types"></param>
		public static void Register(params Type[] types)
		{
			_types.AddRange(types.ToList());
		}

		public static void Register(string implementAssemblyName,string interfaceAssemblyName)
		{
			var implementationAssembly = Assembly.Load(implementAssemblyName);
			var interfaceAssembly = Assembly.Load(interfaceAssemblyName);
			var implementationTypes = implementationAssembly.DefinedTypes.Where(t =>
			  t.IsClass && !t.IsAbstract && !t.IsGenericType && !t.IsNested);
			foreach (var type in implementationTypes)
			{
				var interfaceTypeName = interfaceAssembly + ".I" + type.Name;
				var interfaceType = interfaceAssembly.GetType(interfaceAssemblyName);
				if (interfaceType.IsAssignableFrom(type))
				{
					_dicTypes.Add(interfaceType, type);
				}
			}
		}

		/// <summary>
		/// 注册
		/// </summary>
		/// <typeparam name="TInterface"></typeparam>
		/// <typeparam name="TImplementation"></typeparam>
		public static void Register<TInterface, TImplementation>() where TImplementation : TInterface
		{
			_dicTypes.Add(typeof(TInterface), typeof(TImplementation));
		}

		public static void Register<T>(T instance) where T : class
		{
			_builder.RegisterInstance(instance).SingleInstance();
		}

		/// <summary>
		/// Resolve an instance of the default requested type from the container
		/// </summary>
		/// <typeparam name="T">类型</typeparam>
		/// <returns></returns>
		public static T Resolve<T>()
		{
			return _container.Resolve<T>();
		}

		public static T Resolve<T>(params Parameter[] parameters)
		{
			return _container.Resolve<T>(parameters);
		}

		public static object Resolve(Type targetType)
		{
			return _container.Resolve(targetType);
		}

		public static object Resolve(Type targetType, params Parameter[] parameters)
		{
			return _container.Resolve(targetType, parameters);
		}
	}
}
