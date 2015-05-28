using System;

namespace DotGimei
{
    /// <summary>
    /// ISO 5218に従って性自認を表現します。
    /// </summary>
    public enum GenderIdentity
    {
        /// <summary>コード値0 不明</summary>
        NotKnown = 0,
        /// <summary>コード値1 男性</summary>
        Male = 1,
        /// <summary>コード値2 女性</summary>
        Female = 2,
        /// <summary>コード値9 適用不能</summary>
        NotApplicable = 9
    }
}

