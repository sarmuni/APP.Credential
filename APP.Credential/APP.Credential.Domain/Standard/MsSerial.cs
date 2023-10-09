﻿using APP.Framework.Domain;

using System;

using System.Diagnostics;

/*Generated by .NET Class Generator Tools*/

namespace APP.Credential.Domain
{
    [DebuggerStepThrough()]
    public partial class MsSerial : AbstractTable
    {
        #region Data Member
        private string _serialid;
        private string _serialdesc;
        private string _remark;
        private int _seriallength;
        private int _startnum;
        private int _endnum;
        private int _currentnum;
        private DateTime _tscrt;
        private string _crtusrid;
        private DateTime _tsmod;
        private string _modusrid;
        private string _activeflag = "Y";
        #endregion

        #region Default Value
        public MsSerial()
        {
        }
        #endregion


        #region Properties
        public string SerialID
        {
            get
            {
                return _serialid;
            }
            set
            {
                _serialid = value;
                Modify();
            }
        }

        public string SerialDesc
        {
            get
            {
                return _serialdesc;
            }
            set
            {
                _serialdesc = value;
                Modify();
            }
        }

        public string Remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark = value;
                Modify();
            }
        }

        public int SerialLength
        {
            get
            {
                return _seriallength;
            }
            set
            {
                _seriallength = value;
                Modify();
            }
        }

        public int StartNum
        {
            get
            {
                return _startnum;
            }
            set
            {
                _startnum = value;
                Modify();
            }
        }

        public int EndNum
        {
            get
            {
                return _endnum;
            }
            set
            {
                _endnum = value;
                Modify();
            }
        }

        public int CurrentNum
        {
            get
            {
                return _currentnum;
            }
            set
            {
                _currentnum = value;
                Modify();
            }
        }

        public DateTime TsCrt
        {
            get
            {
                return _tscrt;
            }
            set
            {
                _tscrt = value;
                Modify();
            }
        }

        public string CrtUsrID
        {
            get
            {
                return _crtusrid;
            }
            set
            {
                _crtusrid = value;
                Modify();
            }
        }

        public DateTime TsMod
        {
            get
            {
                return _tsmod;
            }
            set
            {
                _tsmod = value;
                Modify();
            }
        }

        public string ModUsrID
        {
            get
            {
                return _modusrid;
            }
            set
            {
                _modusrid = value;
                Modify();
            }
        }

        public string ActiveFlag
        {
            get
            {
                return _activeflag;
            }
            set
            {
                _activeflag = value;
                Modify();
            }
        }

        #endregion

    }
}