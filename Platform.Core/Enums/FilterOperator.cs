using System;

namespace Platform.Core.Enums
{
    public enum FilterOperator
    {
        [OperaterMap('0', "None")]
        None,

        [OperaterMap('1', "Equal", "{0} = {1}")]
        Equal,

        [OperaterMap('2', "Exact", "{0} = '{1}'")]
        Exact,

        [OperaterMap('3', "Like", "{0} LIKE '%{1}%'")]
        Like,

        [OperaterMap('4', "SoundLike", "{0} SOUNDS LIKE '{1}'")]
        SoundLike

    }

    public class OperaterMapAttribute : Attribute
    {
        internal OperaterMapAttribute(char key, string field, string query = "")
        {
            OperatorKey = key;
            OperatorQuery = query;
        }

        public char OperatorKey { get; private set; }

        public string OperatorQuery { get; private set; }
    }
}
