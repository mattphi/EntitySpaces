/*  New BSD License
-------------------------------------------------------------------------------
Copyright (c) 2006-2012, EntitySpaces, LLC
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the EntitySpaces, LLC nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL EntitySpaces, LLC BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
-------------------------------------------------------------------------------
*/

using EntitySpaces.Interfaces;
using System;
using System.Runtime.Serialization;

namespace EntitySpaces.DynamicQuery
{
    /// <summary>
    /// Used through the internal DynamicQuery classes and contains all of the
    /// information needed to decribe a column, including it's alias (if any),
    /// its DataType, and any JoinAlias to use.
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "es")]
    public struct esColumnItem
    {
        /// <summary>
        /// The column name
        /// </summary>
        [DataMember(Name = "Name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// Returns the column name if there is no Alias, otherwise, returns 
        /// the Alias.
        /// </summary>
        [DataMember(Name = "Alias", EmitDefaultValue = false)]
        public string Alias
        {
            get
            {
                return (this.alias == null) ? Name : this.alias;
            }

            set
            {
                this.alias = value;
            }
        }

        /// <summary>
        /// Returns true if this column has an Alias
        /// </summary>
        public bool HasAlias
        {
            get
            {
                return alias != null;
            }
        }

        [DataMember(Name = "Distinct", EmitDefaultValue = false)]
        public bool Distinct
        {
            get
            {
                return distinct;
            }
            set
            {
                this.distinct= value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ParentQuery", Order = 99, EmitDefaultValue = false)]
        public esDynamicQuery Query;

        /// <summary>
        /// This is passed into the esQueryItem's constructor, it ultimately makes its 
        /// way here
        /// </summary>
        [DataMember(Name = "Datatype", EmitDefaultValue = false)]
        public esSystemType Datatype;

        internal bool IsOutVar;

        private string alias;
        private bool distinct;
    }
}
