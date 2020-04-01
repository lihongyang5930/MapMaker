﻿using System.Data.Entity;
using EntityFramework.Firebird;
using FirebirdSql.Data.FirebirdClient;

namespace MMaker.Core.Dpf
{
    public class FirebirdConfiguration : DbConfiguration
    {
        public FirebirdConfiguration()
        {
            SetProviderServices("FirebirdSql.Data.FirebirdClient", FbProviderServices.Instance);
            SetProviderFactory ("FirebirdSql.Data.FirebirdClient", FirebirdClientFactory.Instance);
            SetDefaultConnectionFactory(new FbConnectionFactory());
        }
    }
}