using NetSwissTools.Exceptions;
using System;
using System.Globalization;

namespace NetSwissTools.Validations
{
    public static class Guard
    {
        /// <summary>
        /// Will throw a <see cref="InvalidOperationException" /> if the assertion
        /// is true, with the specificied message.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <example>
        /// Sample usage:
        /// <code><![CDATA[
        /// Guard.Against(string.IsNullOrEmpty(name), "Name must have a value");
        /// ]]></code></example>
        public static void Against(bool assertion, string message = "")
        {
            if (assertion == false) return;
            throw new InvalidOperationException(message);
        }

        /// <summary>
        /// Will throw a <see cref="InvalidOperationException" /> if the assertion
        /// is true, with the specificied message.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <param name="args">Parametros da mensagem</param>
        /// <exception cref="System.InvalidOperationException"></exception>
        /// <example>
        /// Sample usage:
        /// <code><![CDATA[
        /// Guard.Against(string.IsNullOrEmpty(name), "Name must have a value");
        /// ]]></code></example>
        public static void Against(bool assertion, string message, params object[] args)
        {
            if (assertion == false) return;
            throw new InvalidOperationException(string.Format(message, args));
        }

        /// <summary>
        /// Will throw exception of type <typeparamref name="TException" />
        /// with the specified message if the assertion is true
        /// </summary>
        /// <typeparam name="TException">The type of the t exception.</typeparam>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <param name="beforeThowAction">The action.</param>
        /// <example>
        /// Sample usage:
        /// <code><![CDATA[
        /// Guard.Against<ArgumentException>(string.IsNullOrEmpty(name), "Name must have a value", (ex) => Logger.Erro("Name must have a value"));
        /// ]]></code></example>
        public static void Against<TException>(bool assertion, string message = "", Action<TException> beforeThowAction = null) where TException : Exception
        {
            if (assertion == false) return;
            var exception = (TException)Activator.CreateInstance(typeof(TException), message);
            beforeThowAction?.Invoke(exception);
            throw exception;
        }

        /// <summary>
        /// Will throw exception of type <typeparamref name="TException" />
        /// with the specified message if the assertion is true
        /// </summary>
        /// <typeparam name="TException">The type of the t exception.</typeparam>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        /// <example>
        /// Sample usage:
        /// <code><![CDATA[
        /// Guard.Against<ArgumentException>(string.IsNullOrEmpty(name), "{0} must have a value", Object);
        /// ]]></code></example>
        public static void Against<TException>(bool assertion, string message, params object[] args) where TException : Exception
        {
            if (assertion == false) return;
            throw (TException)Activator.CreateInstance(typeof(TException), string.Format(message, args));
        }



        /// <summary>
        /// Throws an <see cref="NetToolException"/> if the given argument is null.
        /// </summary>
        /// <param name="argumentValue">Argument value to test.</param>
        /// <param name="argumentName">Name of the argument being tested.</param>
        /// <exception cref="NetToolException">If argument value is null</exception>
        public static void ArgumentNotNull(object argumentValue, string argumentName)
        {
            if (argumentValue == null)
            {
                throw new NetToolException(argumentName);
            }
        }

        /// <summary>
        /// Throws an <see cref="NetToolException"/> wrapped in another exception if the given argument is null
        /// </summary>
        /// <typeparam name="TWrapException">Exception type to wrap the <see cref="ArgumentNullException"/> type with</typeparam>
        /// <param name="argumentValue">The argument value</param>
        /// <param name="argumentName">The argument name</param>
        public static void ArgumentNotNull<TWrapException>(object argumentValue, string argumentName)
            where TWrapException : Exception, new()
        {
            if (argumentValue != null)
                return;

            WrapAndThrow<TWrapException, NetToolException>(
                $"Argument '{argumentName}' is null",
                () => new NetToolException(argumentName),
                argumentName);
        }

        /// <summary>
        /// Throws an exception if the tested string argument is null or the empty string.
        /// </summary>
        /// <param name="argumentValue">Argument value to check.</param>
        /// <param name="argumentName">Name of argument being checked.</param>
        /// <exception cref="ArgumentNullException">Thrown if string value is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the string is empty.</exception>
        public static void ArgumentNotNullOrEmpty(string argumentValue, string argumentName)
        {
            ArgumentNotNull(argumentValue, argumentName);

            if (argumentValue.Length == 0)
            {
                throw new NetToolException(
                    $"Argument '{argumentName}' is null",
                    argumentName);
            }
        }

        private static void WrapAndThrow<TWrapException, TInnerException>(string message, Func<TInnerException> innerActivator, string argumentName = null)
            where TWrapException : Exception, new()
            where TInnerException : Exception, new()
        {
            if (Activator.CreateInstance(typeof(TWrapException), message,
                innerActivator.Invoke()) is TWrapException instance)
                throw instance;
            throw new NetToolException(message, argumentName);
        }

        private static void WrapAndThrow<TWrapException>(string message, string argumentName = null)
            where TWrapException : Exception, new()
        {
            if (Activator.CreateInstance(typeof(TWrapException), message,
                new NetToolException(message, argumentName)) is TWrapException instance)
                throw instance;
            throw new NetToolException(message, argumentName);
        }
    }
}

