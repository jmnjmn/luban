using Luban.Job.Common.Types;
using Luban.Job.Common.TypeVisitors;

namespace Luban.Job.Cfg.TypeVisitors
{
    class TsUnderingDeserializeVisitor : ITypeFuncVisitor<string, string, string>
    {
        public static TsUnderingDeserializeVisitor Ins { get; } = new TsUnderingDeserializeVisitor();

        public string Accept(TBool type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TByte type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TShort type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TFshort type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TInt type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TFint type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TLong type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TFlong type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TFloat type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TDouble type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TEnum type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName} as number;";
        }

        public string Accept(TString type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TBytes type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TText type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }

        public string Accept(TBean type, string jsonVarName, string fieldName)
        {
            if (type.Bean.IsAbstractType)
            {
                return $"{fieldName} = {type.Bean.FullName}.deserialize({jsonVarName});";
            }
            else
            {
                return $"{fieldName} = new {type.Bean.FullName}({jsonVarName});";
            }
        }

        public string Accept(TArray type, string jsonVarName, string fieldName)
        {
            if (type.Apply(SimpleJsonTypeVisitor.Ins))
            {
                return $"{fieldName} = {jsonVarName};";
            }
            else
            {
                return $"{{ {fieldName} = []; for(var _ele of {jsonVarName}) {{ let _e :{type.ElementType.Apply(TsDefineTypeName.Ins)};{type.ElementType.Apply(this, "_ele", "_e")} {fieldName}.push(_e);}}}}";
            }
        }

        public string Accept(TList type, string jsonVarName, string fieldName)
        {
            if (type.Apply(SimpleJsonTypeVisitor.Ins))
            {
                return $"{fieldName} = {jsonVarName};";
            }
            else
            {
                return $"{{ {fieldName} = []; for(var _ele of {jsonVarName}) {{ let _e : {type.ElementType.Apply(TsDefineTypeName.Ins)};{type.ElementType.Apply(this, "_ele", "_e")} {fieldName}.push(_e);}}}}";
            }
        }

        public string Accept(TSet type, string jsonVarName, string fieldName)
        {
            if (type.Apply(SimpleJsonTypeVisitor.Ins))
            {
                return $"{fieldName} = {jsonVarName};";
            }
            else
            {
                return $"{{ {fieldName} = new {type.Apply(TsDefineTypeName.Ins)}(); for(var _ele of {jsonVarName}) {{ let _e:{type.ElementType.Apply(TsDefineTypeName.Ins)};{type.ElementType.Apply(this, "_ele", "_e")} {fieldName}.add(_e);}}}}";
            }
        }

        public string Accept(TMap type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = new {type.Apply(TsDefineTypeName.Ins)}(); for(var _entry_ of {jsonVarName}) {{ let _k:{type.KeyType.Apply(TsDefineTypeName.Ins)};  {type.KeyType.Apply(this, "_entry_[0]", "_k")}  let _v:{type.ValueType.Apply(TsDefineTypeName.Ins)};  {type.ValueType.Apply(this, "_entry_[1]", "_v")}     {fieldName}.set(_k, _v);  }}";

        }

        public string Accept(TVector2 type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = Vector2.fromJson({jsonVarName});";
        }

        public string Accept(TVector3 type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = Vector3.fromJson({jsonVarName});";
        }

        public string Accept(TVector4 type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = Vector4.fromJson({jsonVarName});";
        }

        public string Accept(TDateTime type, string jsonVarName, string fieldName)
        {
            return $"{fieldName} = {jsonVarName};";
        }
    }
}
