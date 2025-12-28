using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Services;





namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient(
     new HttpClientHandler
     {
         ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
     })
        {
            BaseAddress = new Uri("https://localhost:7264/")
        };


        [WebMethod]
        public static string PutUser(
                        int id,
                        string name,
                        string lastname,
                        string email,
                        string phone,
                        string dob
                    )
        {
            try
            {
                var putData = new
                {
                    Id = id,
                    Name = name,
                    Lastname = lastname,
                    Email = email,
                    Phone = phone,
                    Dob = string.IsNullOrEmpty(dob) ? null : dob
                };

                var json = JsonConvert.SerializeObject(putData);

                var request = new HttpRequestMessage(HttpMethod.Put, $"api/Users/{id}")
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = client.SendAsync(request).Result;

                return response.IsSuccessStatusCode
                    ? "User updated successfully"
                    : $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }


        [WebMethod]
        public static users GetUserForEdit(int userId)
        {
            try
            {
                HttpResponseMessage response = client.GetAsync($"api/Users/edit/{userId}").Result;
                string json = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    var user = JsonConvert.DeserializeObject<users>(json);
                    return user ?? new users();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetUserForEdit Error: " + ex.Message);
            }

            return new users();
        }


        [WebMethod]
        public static string PatchUser(
             int id,
             string name,
             string lastname,
             string email,
             string phone,
             string dob
           )
        {
            try
            {
                var patchData = new Dictionary<string, object>();

                if (!string.IsNullOrWhiteSpace(name))
                    patchData["name"] = name;

                if (!string.IsNullOrWhiteSpace(lastname))
                    patchData["lastname"] = lastname;

                if (!string.IsNullOrWhiteSpace(email))
                    patchData["email"] = email;

                if (!string.IsNullOrWhiteSpace(phone))
                    patchData["phone"] = phone;

                if (!string.IsNullOrWhiteSpace(dob))
                    patchData["dob"] = dob;

                if (patchData.Count == 0)
                    return "Error: No fields provided for update";

                var json = JsonConvert.SerializeObject(patchData);

                var request = new HttpRequestMessage(
                    new HttpMethod("PATCH"),
                    $"api/Users/{id}")
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = client.SendAsync(request).Result;

                return response.IsSuccessStatusCode
                    ? "User updated successfully"
                    : $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        [WebMethod]
        public static string PatchUnits(int id, int units)
        {
            try
            {
                if (units < 0)
                    return "Error: Units value cannot be negative";

                var patchData = new Dictionary<string, object>
                {
                    { "units", units }
                };

                var json = JsonConvert.SerializeObject(patchData);

                var request = new HttpRequestMessage(
                    new HttpMethod("PATCH"),
                    $"api/Users/{id}")
                {
                    Content = new StringContent(json, Encoding.UTF8, "application/json")
                };

                HttpResponseMessage response = client.SendAsync(request).Result;

                return response.IsSuccessStatusCode
                    ? "Success"
                    : $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }





        [WebMethod]
        public static List<users> Recall()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync("api/Users").Result;
                string json = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<List<users>>(json) ?? new List<users>();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetSkills Error: " + ex.Message);
            }

            return new List<users>();
        }

        [WebMethod]
        public static string InsertUserData(
            string name,
            string lastname,
            string email,
            long phone,
            string dob,
            int countryid,
            int stateid,
            int districtid,
            string skills,
            string submitted)
        {
            try
            {
                var user = new
                {
                    name,
                    lastname,
                    email,
                    phone = phone.ToString(),
                    dob = DateTime.Parse(dob).ToString("yyyy-MM-dd"),
                    countryId = countryid,
                    stateId = stateid,
                    districtId = districtid,
                    skills,
                    submitted
                };

                var json = JsonConvert.SerializeObject(user);
                Console.WriteLine("JSON being sent:");
                Console.WriteLine(json);


                var content = new StringContent(
                    JsonConvert.SerializeObject(user),
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = client.PostAsync("api/users", content).Result;

                return response.IsSuccessStatusCode
                    ? "Data inserted successfully!"
                    : $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        [WebMethod]
        public static List<DropdownItem> GetCountries()
        {
            try
            {
                HttpResponseMessage response = client.GetAsync("api/Users/proj_country").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    var countries = JsonConvert.DeserializeObject<List<ProjCountry>>(json);



                    return countries.Select(c => new DropdownItem
                    {
                        Id = c.CountryId,
                        Name = c.CountryNames
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                return new List<DropdownItem>
                {
                    new DropdownItem {  Name = ex.Message }
                };
            }

            return new List<DropdownItem>();
        }

        [WebMethod]
        public static List<DropdownItem> GetStates(int countryId)
        {
            try
            {
                using (var localClient = new HttpClient())
                {
                    string url = $"https://localhost:7264/api/Users/proj_state?countryId={countryId}";
                    HttpResponseMessage response = localClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;
                        var states = JsonConvert.DeserializeObject<List<StateModel>>(json);

                        return states.Select(s => new DropdownItem
                        {
                            Id = s.StateId,
                            Name = s.StateNames
                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<DropdownItem>
                {
                    new DropdownItem {  Name = ex.Message }
                };
            }

            return new List<DropdownItem>();
        }

        [WebMethod]
        public static List<DropdownItem> GetDistricts(int stateId)
        {
            try
            {
                using (var localClient = new HttpClient())
                {
                    string url = $"https://localhost:7264/api/Users/proj_district?stateId={stateId}";
                    HttpResponseMessage response = localClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string json = response.Content.ReadAsStringAsync().Result;
                        var districts = JsonConvert.DeserializeObject<List<DistrictModel>>(json);

                        return districts.Select(d => new DropdownItem
                        {
                            Id = d.DistrictId,
                            Name = d.DistrictNames
                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<DropdownItem>
                {
                    new DropdownItem { Id = -1, Name = ex.Message }
                };
            }

            return new List<DropdownItem>();
        }

        [WebMethod]
        public static string DeleteUser(string userId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7264/");


                    HttpResponseMessage response = client.DeleteAsync($"api/users/{userId}").Result;


                    if (response.IsSuccessStatusCode)
                    {
                        return "User deleted successfully!";
                    }
                    else
                    {
                        return $"Error: {response.ReasonPhrase}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }




        //[WebMethod]
        //public static string DeleteUser(string userId)
        //{
        //    try
        //    {
        //        client.BaseAddress = new Uri(apiBaseUrl);
        //        HttpResponseMessage response = client.DeleteAsync($"api/users/{userId}").Result;

        //        return response.IsSuccessStatusCode ? "User deleted successfully!" : $"Error: {response.ReasonPhrase}";
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Error: {ex.Message}";
        //    }
        //}





        public class DistrictModel
        {
            public int DistrictId { get; set; }
            public string DistrictNames { get; set; }
            public int StateId { get; set; }
        }

        public class StateModel
        {
            public int StateId { get; set; }
            public string StateNames { get; set; }
        }

        public class ProjCountry
        {
            public int CountryId { get; set; }
            public string CountryNames { get; set; }
        }

        public class DropdownItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class users
        {
            public int id { get; set; }
            public string name { get; set; }
            public string lastname { get; set; }
            public string email { get; set; }
            public string phone { get; set; }
            public string dob { get; set; }
            public string submitted { get; set; }
            public string skills { get; set; }
            public int isDeleted { get; set; }

            public DateTime SubmittedDateTime { get; set; }
            public int? units { get; set; }

            public int? countryId { get; set; }
            public string countryName { get; set; }

            public int? stateId { get; set; }
            public string stateName { get; set; }

            public int? districtId { get; set; }
            public string districtName { get; set; }
        }
    }
}

