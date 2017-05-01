#region

using System;
using System.Dynamic;
using ESAPIX.Extensions;
using X = ESAPIX.Facade.XContext;

#endregion

namespace ESAPIX.Facade.Types
{
    public class SmartLMCOptions
    {
        internal dynamic _client;

        public SmartLMCOptions()
        {
            _client = new ExpandoObject();
        }

        public SmartLMCOptions(dynamic client)
        {
            _client = client;
        }

        public SmartLMCOptions(bool fixedFieldBorders, bool jawTracking)
        {
            if (X.Instance.CurrentContext != null)
                X.Instance.CurrentContext.Thread.Invoke(() =>
                {
                    _client = VMSConstructor.ConstructSmartLMCOptions(fixedFieldBorders, jawTracking);
                });
            else throw new Exception("There is no VMS Context to create the class");
        }

        public bool IsLive
        {
            get { return !DefaultHelper.IsDefault(_client) && !(_client is ExpandoObject); }
        }

        public bool FixedFieldBorders
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("FixedFieldBorders")
                        ? _client.FixedFieldBorders
                        : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.FixedFieldBorders; });
            }
            set
            {
                if (_client is ExpandoObject) _client.FixedFieldBorders = value;
            }
        }

        public bool JawTracking
        {
            get
            {
                if (_client is ExpandoObject)
                    return (_client as ExpandoObject).HasProperty("JawTracking") ? _client.JawTracking : default(bool);
                var local = this;
                return X.Instance.CurrentContext.GetValue<bool>(sc => { return local._client.JawTracking; });
            }
            set
            {
                if (_client is ExpandoObject) _client.JawTracking = value;
            }
        }
    }
}