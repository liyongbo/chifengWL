﻿using System; 

namespace Entity
{
	 	//Role
		[Serializable]
	public class Role
	{
   		     
      	/// <summary>
		/// id
        /// </summary>		
		private int _id;
        public int id
        {
            get{ return _id; }
            set{ _id = value; }
        }        
		/// <summary>
		/// rolename
        /// </summary>		
		private string _rolename;
        public string rolename
        {
            get{ return _rolename; }
            set{ _rolename = value; }
        }        
		/// <summary>
		/// param1
        /// </summary>		
		private string _param1;
        public string param1
        {
            get{ return _param1; }
            set{ _param1 = value; }
        }        
		/// <summary>
		/// param2
        /// </summary>		
		private string _param2;
        public string param2
        {
            get{ return _param2; }
            set{ _param2 = value; }
        }        
		   
	}
}