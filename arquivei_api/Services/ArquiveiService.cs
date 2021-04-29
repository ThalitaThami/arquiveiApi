using arquivei_api.Models;
using arquivei_api.Repositories;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace arquivei_api.Services
{ 
    public class ArquiveiService
    {
        protected readonly string BaseAddress = "https://sandbox-api.arquivei.com.br";
        protected readonly string XApiId = "d5cc4e8dcadda1f64ad104617eddf86f7c7b5597";
        protected readonly string XApiKey = "813496c663627f7919b2dfc5949cd7495026606c";
        protected readonly string Version = "v1";
        private INfeRepository _nfeRepository;

        public ArquiveiService(INfeRepository nfeRepository)
        {
            _nfeRepository = nfeRepository ?? throw new ArgumentNullException(nameof(nfeRepository));
        }

        public async Task<Nfe> GetReceivedNFesByAccessKeyAsync(string accessKey)
        {

            Nfe nfe = null;
            var result = GetReceivedByAccessKey(accessKey);

            if (result.Code == "200")
            {   
                nfe = new Nfe()
                {
                    AccessKey = accessKey,
                    Xml = result.Xml
                };

                nfe.CalculateTotal();

                try
                {
                    await _nfeRepository.InsertAsync(nfe);
                }
                catch (Exception ex)
                {
                    // dRecord already exists in the database
                }
            }

            return nfe;            
        }

        private SimpleResponseDto GetReceivedByAccessKey(string accessKey)
        {
            try
            {
                JObject result;

                using (WebClient client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    client.Headers.Add("x-api-id", XApiId);
                    client.Headers.Add("x-api-key", XApiKey);
                    client.Headers.Add("Content-Type", "application/json");

                    var url = $"{BaseAddress}/{Version}/nfe/received?access_key[]={accessKey}";
                    var json = client.DownloadString(url);

                    result = JsonConvert.DeserializeObject<JObject>(json);
                }

                return new SimpleResponseDto()
                {
                    Code = result.GetValue("status")["code"].ToString(),
                    Xml = result.GetValue("data")[0]["xml"].ToString()
                };

            }
            catch(Exception ex)
            {
                return new SimpleResponseDto()
                {
                    Code = "400"
                };
            }
            
        }                
        
    }
}
