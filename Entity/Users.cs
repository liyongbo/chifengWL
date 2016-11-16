using System; 

namespace Entity
{
	 	//Users
		[Serializable]
	public class Users
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
		/// username
        /// </summary>		
		private string _username;
        public string username
        {
            get{ return _username; }
            set{ _username = value; }
        }        
		/// <summary>
		/// userpassword
        /// </summary>		
		private string _userpassword;
        public string userpassword
        {
            get{ return _userpassword; }
            set{ _userpassword = value; }
        }        
		/// <summary>
		/// tel
        /// </summary>		
		private string _tel;
        public string tel
        {
            get{ return _tel; }
            set{ _tel = value; }
        }        
		/// <summary>
		/// email
        /// </summary>		
		private string _email;
        public string email
        {
            get{ return _email; }
            set{ _email = value; }
        }        
		/// <summary>
		/// qq
        /// </summary>		
		private string _qq;
        public string qq
        {
            get{ return _qq; }
            set{ _qq = value; }
        }        
		/// <summary>
		/// name
        /// </summary>		
		private string _name;
        public string name
        {
            get{ return _name; }
            set{ _name = value; }
        }        
		/// <summary>
		/// createdate
        /// </summary>		
		private string _createdate;
        public string createdate
        {
            get{ return _createdate; }
            set{ _createdate = value; }
        }        
		/// <summary>
		/// lastloginip
        /// </summary>		
		private string _lastloginip;
        public string lastloginip
        {
            get{ return _lastloginip; }
            set{ _lastloginip = value; }
        }        
		/// <summary>
		/// lastlogintime
        /// </summary>		
		private string _lastlogintime;
        public string lastlogintime
        {
            get{ return _lastlogintime; }
            set{ _lastlogintime = value; }
        }        
		   
	}
}