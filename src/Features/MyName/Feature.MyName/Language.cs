using App.Shared.Globalisation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Feature.MyName
{
    public static class Languages
    {
        public static IReadOnlyDictionary<string, Text> String = new Dictionary<string, Text>
        {
            {
                "TypeYourName", new Text
                (
                    en : "Type your name",
                    nl : "Typ uw naam"
                )
            },
            {
                "Submit", new Text
                (
                    en : "Submit",
                    nl : "Aanmelden"
                )
            },
        };
    }
}
