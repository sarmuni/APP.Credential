using APP.Credential.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APP.Credential.Api.Controllers
{
    public class DomainController : ApiController
    {
        [HttpGet]
        public ResultDomain Get()
        {
            DomainData data = new DomainData();
            List<DomainData> lstData = new List<DomainData>();
            ResultDomain res = new ResultDomain();
            res.success = true;
            res.code = 200;
            res.message = "Data Found";

            data = new DomainData();
            data.domainCode = "IKS";
            data.domainName = "Indah Kiat Serang";
            lstData.Add(data);

            data = new DomainData();
            data.domainCode = "IKT";
            data.domainName = "Indah Kiat Tangerang";
            lstData.Add(data);

            data = new DomainData();
            data.domainCode = "IKP";
            data.domainName = "Indah Kiat Perawang";
            lstData.Add(data);

            data = new DomainData();
            data.domainCode = "PDK1";
            data.domainName = "Pindo Deli Karawang #1";
            lstData.Add(data);

            data = new DomainData();
            data.domainCode = "PDK2";
            data.domainName = "Pindo Deli Karawang #2";
            lstData.Add(data);

            data = new DomainData();
            data.domainCode = "PDK3";
            data.domainName = "Pindo Deli Karawang #3";
            lstData.Add(data);

            data = new DomainData();
            data.domainCode = "PDK4";
            data.domainName = "Pindo Deli Karawang #4";
            lstData.Add(data);

            data = new DomainData();
            data.domainCode = "TKM";
            data.domainName = "Tjiwi Kimia Mojokerto";
            lstData.Add(data);

            data = new DomainData();
            data.domainCode = "EMF";
            data.domainName = "Eka Mas Fortuna";
            lstData.Add(data);

            res.data = lstData;

            return res;
        }
    }
}
