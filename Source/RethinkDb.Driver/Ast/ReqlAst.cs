﻿using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RethinkDb.Driver.Model;
using RethinkDb.Driver.Net;
using RethinkDb.Driver.Proto;

namespace RethinkDb.Driver.Ast
{

	/// <summary>
	/// Base class for all reql queries.
	/// </summary>
	public class ReqlAst
	{
        protected internal readonly ReqlAst prev;
        protected internal readonly TermType termType;
        protected internal readonly Arguments args;
        protected internal readonly OptArgs optargs;

        protected internal ReqlAst(ReqlAst prev, TermType termType, Arguments args, OptArgs optargs)
        {
            this.prev = prev;
            if( termType == null )
            {
                throw new ReqlDriverError("termType can't be null!");
            }
            this.termType = termType;
            this.args = new Arguments();
            if( prev != null )
            {
                this.args.Add(prev);
            }
            if( args != null )
            {
                this.args.AddRange(args);
            }
            this.optargs = optargs != null ? optargs : new OptArgs();
        }

        protected internal ReqlAst(TermType termType, Arguments args) : this(null, termType, args, null)
        {
        }

        protected internal virtual object build()
        {
            // Create a JSON object from the Ast
            JArray list = new JArray();
            list.Add(termType);
            if( args.Count > 0 )
            {
                list.Add(args.Select(a => a.build()).ToList());
            }
            else
            {
                list.Add(new JArray());
            }
            if( optargs.Count > 0 )
            {
                JObject joptargs = new JObject();
                foreach( KeyValuePair<string, ReqlAst> entry in optargs )
                {
                    joptargs.Add(entry.Key, (JToken)entry.Value.build());
                }
                list.Add(joptargs);
            }
            return list;
        }

        public virtual object run<T>(Connection conn, GlobalOptions g)
        {
            return conn.run<T>(this, g);
        }

        public virtual object run<T>(Connection conn)
        {
            return conn.run<T>(this, new GlobalOptions());
        }

        public override string ToString()
        {
            return "ReqlAst{" + "prev=" + prev + ", termType=" + termType + ", args=" + args + ", optargs=" + optargs + '}';
        }

    }

}