﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIWebApplicationBLL.Repository
{
    public class Cls_Menu
    {
        private long _MenuID;
        private string _MenuName;

        private long _QueryID;

        public long MenuID
        {
            get
            {
                return this._MenuID;
            }
            set
            {
                this._MenuID = value;
            }
        }
        public string MenuName
        {
            get
            {
                return this._MenuName;
            }
            set
            {
                this._MenuName = value;
            }
        }
        public long QueryID
        {
            get
            {
                return this._QueryID;
            }
            set
            {
                this._QueryID = value;
            }
        }

       


    }
}
