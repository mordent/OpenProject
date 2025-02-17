﻿using MySql.Data.MySqlClient;
using NpgsqlTypes;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ThiRA.Base.Infos;

public class DataType
{
    public const string COLUMN_NAME = "COLUMN_NAME";
    public const string DATA_TYPE = "DATA_TYPE";

    public static readonly Dictionary<TypeCode, DbType> TYPE_DB_TYPE_MAP = new Dictionary<TypeCode, DbType>() {
        {TypeCode.Empty   , DbType.String           },
        {TypeCode.Object  , DbType.Object           },
        {TypeCode.DBNull  , DbType.String           },
        {TypeCode.Boolean , DbType.Boolean          },
        {TypeCode.Char    , DbType.StringFixedLength},
        {TypeCode.SByte   , DbType.SByte            },
        {TypeCode.Byte    , DbType.Byte             },
        {TypeCode.Int16   , DbType.Int16            },
        {TypeCode.UInt16  , DbType.UInt16           },
        {TypeCode.Int32   , DbType.Int32            },
        {TypeCode.UInt32  , DbType.UInt32           },
        {TypeCode.Int64   , DbType.Int64            },
        {TypeCode.UInt64  , DbType.UInt64           },
        {TypeCode.Single  , DbType.Single           },
        {TypeCode.Double  , DbType.Double           },
        {TypeCode.Decimal , DbType.Decimal          },
        {TypeCode.DateTime, DbType.DateTime         },
        {TypeCode.String  , DbType.String           },
    };
    #region MSSQL
    public static readonly Dictionary<TypeCode, SqlDbType> MSSQL_TYPE_DB_TYPE_MAP = new Dictionary<TypeCode, SqlDbType>() {
        {TypeCode.Empty   , SqlDbType.Text     },
        {TypeCode.Object  , SqlDbType.Text     },
        {TypeCode.DBNull  , SqlDbType.Text     },
        {TypeCode.Boolean , SqlDbType.Bit      },
        {TypeCode.Char    , SqlDbType.Char     },
        {TypeCode.SByte   , SqlDbType.Binary   },
        {TypeCode.Byte    , SqlDbType.Binary   },
        {TypeCode.Int16   , SqlDbType.SmallInt },
        {TypeCode.UInt16  , SqlDbType.SmallInt },
        {TypeCode.Int32   , SqlDbType.Int      },
        {TypeCode.UInt32  , SqlDbType.Int      },
        {TypeCode.Int64   , SqlDbType.BigInt   },
        {TypeCode.UInt64  , SqlDbType.BigInt   },
        {TypeCode.Single  , SqlDbType.Real     },
        {TypeCode.Double  , SqlDbType.Float    },
        {TypeCode.Decimal , SqlDbType.Decimal  },
        {TypeCode.DateTime, SqlDbType.Timestamp},
        {TypeCode.String  , SqlDbType.Text     },
    };
    public static readonly Dictionary<DbType, SqlDbType> MSSQL_DB_TYPE_DB_TYPE_MAP = new Dictionary<DbType, SqlDbType>() {
        {DbType.AnsiString           ,SqlDbType.Text            },
        {DbType.Binary               ,SqlDbType.Binary          },
        {DbType.Byte                 ,SqlDbType.Binary          },
        {DbType.Boolean              ,SqlDbType.Bit             },
        {DbType.Currency             ,SqlDbType.Decimal         },
        {DbType.Date                 ,SqlDbType.Date            },
        {DbType.DateTime             ,SqlDbType.DateTime        },
        {DbType.Decimal              ,SqlDbType.Decimal         },
        {DbType.Double               ,SqlDbType.Float           },
        {DbType.Guid                 ,SqlDbType.UniqueIdentifier},
        {DbType.Int16                ,SqlDbType.SmallInt        },
        {DbType.Int32                ,SqlDbType.Int             },
        {DbType.Int64                ,SqlDbType.BigInt          },
        {DbType.Object               ,SqlDbType.Variant         },
        {DbType.SByte                ,SqlDbType.Binary          },
        {DbType.Single               ,SqlDbType.Real            },
        {DbType.String               ,SqlDbType.Text            },
        {DbType.Time                 ,SqlDbType.Time            },
        {DbType.UInt16               ,SqlDbType.SmallInt        },
        {DbType.UInt32               ,SqlDbType.Int             },
        {DbType.UInt64               ,SqlDbType.BigInt          },
        {DbType.VarNumeric           ,SqlDbType.Variant         },
        {DbType.AnsiStringFixedLength,SqlDbType.Char            },
        {DbType.StringFixedLength    ,SqlDbType.NChar           },
        {DbType.Xml                  ,SqlDbType.Xml             },
        {DbType.DateTime2            ,SqlDbType.DateTime2       },
        {DbType.DateTimeOffset       ,SqlDbType.DateTimeOffset  },
    };
    #endregion MSSQL
    #region MYSQL
    public static readonly Dictionary<TypeCode, MySqlDbType> MYSQL_TYPE_DB_TYPE_MAP = new Dictionary<TypeCode, MySqlDbType>() {
        {TypeCode.Empty   , MySqlDbType.Text     },
        {TypeCode.Object  , MySqlDbType.Text     },
        {TypeCode.DBNull  , MySqlDbType.Text     },
        {TypeCode.Boolean , MySqlDbType.Bit      },
        {TypeCode.Char    , MySqlDbType.VarChar  },
        {TypeCode.SByte   , MySqlDbType.Binary   },
        {TypeCode.Byte    , MySqlDbType.Binary   },
        {TypeCode.Int16   , MySqlDbType.Int16    },
        {TypeCode.UInt16  , MySqlDbType.UInt16   },
        {TypeCode.Int32   , MySqlDbType.Int32    },
        {TypeCode.UInt32  , MySqlDbType.UInt32   },
        {TypeCode.Int64   , MySqlDbType.Int64    },
        {TypeCode.UInt64  , MySqlDbType.UInt64   },
        {TypeCode.Single  , MySqlDbType.Float    },
        {TypeCode.Double  , MySqlDbType.Double   },
        {TypeCode.Decimal , MySqlDbType.Decimal  },
        {TypeCode.DateTime, MySqlDbType.Timestamp},
        {TypeCode.String  , MySqlDbType.Text     },
    };
    public static readonly Dictionary<DbType, MySqlDbType> MYSQL_DB_TYPE_DB_TYPE_MAP = new Dictionary<DbType, MySqlDbType>() {
        {DbType.AnsiString           ,MySqlDbType.Text      },
        {DbType.Binary               ,MySqlDbType.Binary    },
        {DbType.Byte                 ,MySqlDbType.Byte      },
        {DbType.Boolean              ,MySqlDbType.Bit       },
        {DbType.Currency             ,MySqlDbType.Double    },
        {DbType.Date                 ,MySqlDbType.Date      },
        {DbType.DateTime             ,MySqlDbType.DateTime  },
        {DbType.Decimal              ,MySqlDbType.Double    },
        {DbType.Double               ,MySqlDbType.Double    },
        {DbType.Guid                 ,MySqlDbType.Guid      },
        {DbType.Int16                ,MySqlDbType.Int16     },
        {DbType.Int32                ,MySqlDbType.Int32     },
        {DbType.Int64                ,MySqlDbType.Int64     },
        {DbType.Object               ,MySqlDbType.Text      },
        {DbType.SByte                ,MySqlDbType.Byte      },
        {DbType.Single               ,MySqlDbType.Float     },
        {DbType.String               ,MySqlDbType.LongText  },
        {DbType.Time                 ,MySqlDbType.Time      },
        {DbType.UInt16               ,MySqlDbType.UInt16    },
        {DbType.UInt32               ,MySqlDbType.UInt32    },
        {DbType.UInt64               ,MySqlDbType.UInt64    },
        {DbType.VarNumeric           ,MySqlDbType.NewDecimal},
        {DbType.AnsiStringFixedLength,MySqlDbType.String    },
        {DbType.StringFixedLength    ,MySqlDbType.String    },
        {DbType.Xml                  ,MySqlDbType.LongText  },
        {DbType.DateTime2            ,MySqlDbType.Newdate   },
        {DbType.DateTimeOffset       ,MySqlDbType.Newdate   },
    };
    #endregion MYSQL
    #region Oracle
    public static readonly Dictionary<TypeCode, OracleDbType> ORACLE_TYPE_DB_TYPE_MAP = new Dictionary<TypeCode, OracleDbType>() {
        {TypeCode.Empty   , OracleDbType.NVarchar2},
        {TypeCode.Object  , OracleDbType.Object   },
        {TypeCode.DBNull  , OracleDbType.NVarchar2},
        {TypeCode.Boolean , OracleDbType.Boolean  },
        {TypeCode.Char    , OracleDbType.Char     },
        {TypeCode.SByte   , OracleDbType.Byte     },
        {TypeCode.Byte    , OracleDbType.Byte     },
        {TypeCode.Int16   , OracleDbType.Int16    },
        {TypeCode.UInt16  , OracleDbType.Int16    },
        {TypeCode.Int32   , OracleDbType.Int32    },
        {TypeCode.UInt32  , OracleDbType.Int32    },
        {TypeCode.Int64   , OracleDbType.Int64    },
        {TypeCode.UInt64  , OracleDbType.Int64    },
        {TypeCode.Single  , OracleDbType.Single   },
        {TypeCode.Double  , OracleDbType.Double   },
        {TypeCode.Decimal , OracleDbType.Decimal  },
        {TypeCode.DateTime, OracleDbType.TimeStamp},
        {TypeCode.String  , OracleDbType.NVarchar2},
    };
    public static readonly Dictionary<DbType, OracleDbType> ORACLE_DB_TYPE_DB_TYPE_MAP = new Dictionary<DbType, OracleDbType>() {
        {DbType.AnsiString           ,OracleDbType.Varchar2    },
        {DbType.Binary               ,OracleDbType.Raw         },
        {DbType.Byte                 ,OracleDbType.Byte        },
        {DbType.Boolean              ,OracleDbType.Boolean     },
        {DbType.Currency             ,OracleDbType.Decimal     },
        {DbType.Date                 ,OracleDbType.Date        },
        {DbType.DateTime             ,OracleDbType.TimeStamp   },
        {DbType.Decimal              ,OracleDbType.Decimal     },
        {DbType.Double               ,OracleDbType.Double      },
        {DbType.Guid                 ,OracleDbType.Varchar2    },
        {DbType.Int16                ,OracleDbType.Int16       },
        {DbType.Int32                ,OracleDbType.Int32       },
        {DbType.Int64                ,OracleDbType.Int64       },
        {DbType.Object               ,OracleDbType.Object      },
        {DbType.SByte                ,OracleDbType.Byte        },
        {DbType.Single               ,OracleDbType.Single      },
        {DbType.String               ,OracleDbType.NVarchar2   },
        {DbType.Time                 ,OracleDbType.TimeStamp   },
        {DbType.UInt16               ,OracleDbType.Int16       },
        {DbType.UInt32               ,OracleDbType.Int32       },
        {DbType.UInt64               ,OracleDbType.Int64       },
        {DbType.VarNumeric           ,OracleDbType.Decimal     },
        {DbType.AnsiStringFixedLength,OracleDbType.Char        },
        {DbType.StringFixedLength    ,OracleDbType.NChar       },
        {DbType.Xml                  ,OracleDbType.XmlType     },
        {DbType.DateTime2            ,OracleDbType.TimeStamp   },
        {DbType.DateTimeOffset       ,OracleDbType.TimeStampLTZ},

    };
    #endregion Oracle
    #region PostgreSQL
    public static readonly Dictionary<TypeCode, NpgsqlDbType> NPGSQL_TYPE_DB_TYPE_MAP = new Dictionary<TypeCode, NpgsqlDbType>() {
        {TypeCode.Empty   , NpgsqlDbType.Text     },
        {TypeCode.Object  , NpgsqlDbType.Text     },
        {TypeCode.DBNull  , NpgsqlDbType.Text     },
        {TypeCode.Boolean , NpgsqlDbType.Boolean  },
        {TypeCode.Char    , NpgsqlDbType.Char     },
        {TypeCode.SByte   , NpgsqlDbType.Bytea    },
        {TypeCode.Byte    , NpgsqlDbType.Bytea    },
        {TypeCode.Int16   , NpgsqlDbType.Smallint },
        {TypeCode.UInt16  , NpgsqlDbType.Smallint },
        {TypeCode.Int32   , NpgsqlDbType.Bigint   },
        {TypeCode.UInt32  , NpgsqlDbType.Smallint },
        {TypeCode.Int64   , NpgsqlDbType.Bigint   },
        {TypeCode.UInt64  , NpgsqlDbType.Bigint   },
        {TypeCode.Single  , NpgsqlDbType.Real     },
        {TypeCode.Double  , NpgsqlDbType.Double   },
        {TypeCode.Decimal , NpgsqlDbType.Numeric  },
        {TypeCode.DateTime, NpgsqlDbType.Timestamp},
        {TypeCode.String  , NpgsqlDbType.Text     },
    };
    public static readonly Dictionary<DbType, NpgsqlDbType> NPGSQL_DB_TYPE_DB_TYPE_MAP = new Dictionary<DbType, NpgsqlDbType>() {
        {DbType.AnsiString           ,NpgsqlDbType.Char       },
        {DbType.Binary               ,NpgsqlDbType.Bytea      },
        {DbType.Byte                 ,NpgsqlDbType.Bytea      },
        {DbType.Boolean              ,NpgsqlDbType.Boolean    },
        {DbType.Currency             ,NpgsqlDbType.Money      },
        {DbType.Date                 ,NpgsqlDbType.Date       },
        {DbType.DateTime             ,NpgsqlDbType.Timestamp  },
        {DbType.Decimal              ,NpgsqlDbType.Real       },
        {DbType.Double               ,NpgsqlDbType.Double     },
        {DbType.Guid                 ,NpgsqlDbType.Text       },
        {DbType.Int16                ,NpgsqlDbType.Smallint   },
        {DbType.Int32                ,NpgsqlDbType.Integer    },
        {DbType.Int64                ,NpgsqlDbType.Bigint     },
        {DbType.Object               ,NpgsqlDbType.Text       },
        {DbType.SByte                ,NpgsqlDbType.Bytea      },
        {DbType.Single               ,NpgsqlDbType.Real       },
        {DbType.String               ,NpgsqlDbType.Text       },
        {DbType.Time                 ,NpgsqlDbType.Time       },
        {DbType.UInt16               ,NpgsqlDbType.Smallint   },
        {DbType.UInt32               ,NpgsqlDbType.Integer    },
        {DbType.UInt64               ,NpgsqlDbType.Bigint     },
        {DbType.VarNumeric           ,NpgsqlDbType.Numeric    },
        {DbType.AnsiStringFixedLength,NpgsqlDbType.Char       },
        {DbType.StringFixedLength    ,NpgsqlDbType.Char       },
        {DbType.Xml                  ,NpgsqlDbType.Xml        },
        {DbType.DateTime2            ,NpgsqlDbType.Timestamp  },
        {DbType.DateTimeOffset       ,NpgsqlDbType.TimestampTz},
    };
    #endregion PostgreSQL

    public static DataTypeInfo GetDataTypeInfo(Type dataType)
    {
        return new DataTypeInfo(dataType);
    }
}
