using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Dealership.Common.Utilities;

namespace Dealership.Engine
{
    public class Command : ICommand
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private string name;
        private IList<string> parameters;

        public Command(string input)
        {
            this.Parameters = new List<string>();
            this.TranslateInput(input);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {

                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IList<string> Parameters
        {
            get
            {
                return this.parameters;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The parameters cannot be null.");
                }

                this.parameters = value;
            }
        }

        private void TranslateInput(string input)
        {
            int indexOfFirstSeparator = input.IndexOf(SplitCommandSymbol);
            int indexOfOpenComment = input.IndexOf(CommentOpenSymbol);
            int indexOfCloseComment = input.IndexOf(CommentCloseSymbol);

            var regex = new Regex("{{.+(?=}})}}");

            if (indexOfFirstSeparator < 0)
            {
                this.Name = input;
                return;
            }

            this.Name = input.Substring(0, indexOfFirstSeparator);

            if (indexOfOpenComment >= 0)
            {
                this.Parameters.Add(
                    input.Substring(indexOfOpenComment + CommentOpenSymbol.Length, 
                    indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment));

                input = regex.Replace(input, string.Empty);
            }

            string[] parameters = input.Substring(indexOfFirstSeparator + 1)
                .Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries);
            this.Parameters.AddRange(parameters);
        }
    }
}
