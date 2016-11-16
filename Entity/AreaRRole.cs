using System; 

namespace Entity
{
	 	//AreaRRole
		[Serializable]
	public class AreaRRole
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
		/// regonid
        /// </summary>		
		private int _regonid;
        public int regonid
        {
            get{ return _regonid; }
            set{ _regonid = value; }
        }        
		/// <summary>
		/// regonname
        /// </summary>		
		private string _regonname;
        public string regonname
        {
            get{ return _regonname; }
            set{ _regonname = value; }
        }        
		/// <summary>
		/// roleid
        /// </summary>		
		private int _roleid;
        public int roleid
        {
            get{ return _roleid; }
            set{ _roleid = value; }
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
		   
	}
}