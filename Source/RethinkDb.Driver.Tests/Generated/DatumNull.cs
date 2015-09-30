




//AUTOGENERATED, DO NOTMODIFY.
//Do not edit this file directly.

#pragma warning disable 1591
// ReSharper disable CheckNamespace

using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using RethinkDb.Driver.Model;
using RethinkDb.Driver.Ast;
using NUnit.Framework;
using RethinkDb.Driver.Tests;

namespace RethinkDb.Driver.Test.Generated {
    [TestFixture]
    public class DatumNull : GeneratedTest {



        [Test]
        public void YamlTest(){

             
             {
                 //JavaQuery, datum/null.yaml, #1
                 //ExpectedOriginal: (null)
                 var expected = null as object;
                 
                 //Original: r.expr(null)
                 var obtained = runOrCatch( r.expr(null) ,
                                            new OptArgs()
                    );
                 assertEquals(expected, obtained);
             }
             
             
             {
                 //JavaQuery, datum/null.yaml, #2
                 //ExpectedOriginal: NULL
                 var expected = "NULL";
                 
                 //Original: r.expr(null).type_of()
                 var obtained = runOrCatch( r.expr(null).typeOf() ,
                                            new OptArgs()
                    );
                 assertEquals(expected, obtained);
             }
             
             
             {
                 //JavaQuery, datum/null.yaml, #3
                 //ExpectedOriginal: null
                 var expected = "null";
                 
                 //Original: r.expr(null).coerce_to('string')
                 var obtained = runOrCatch( r.expr(null).coerceTo("string") ,
                                            new OptArgs()
                    );
                 assertEquals(expected, obtained);
             }
             
             
             {
                 //JavaQuery, datum/null.yaml, #4
                 //ExpectedOriginal: (null)
                 var expected = null as object;
                 
                 //Original: r.expr(null).coerce_to('null')
                 var obtained = runOrCatch( r.expr(null).coerceTo("null") ,
                                            new OptArgs()
                    );
                 assertEquals(expected, obtained);
             }
             

        }
    }
}