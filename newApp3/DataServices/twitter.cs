﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace newApp3.DataServices
{
    //public class twitter
    //{
    //    public const string OauthVersion = "1.0";
    //    public const string OauthSignatureMethod = "HMAC-SHA1";

    //    public twitter
    //      (string consumerKey, string consumerKeySecret, string accessToken, string accessTokenSecret)
    //    {
    //        this.ConsumerKey = consumerKey;
    //        this.ConsumerKeySecret = consumerKeySecret;
    //        this.AccessToken = accessToken;
    //        this.AccessTokenSecret = accessTokenSecret;
    //    }

    //    public string ConsumerKey { set; get; }
    //    public string ConsumerKeySecret { set; get; }
    //    public string AccessToken { set; get; }
    //    public string AccessTokenSecret { set; get; }

    //    public string GetMentions(int count)
    //    {
    //        string resourceUrl =
    //            string.Format("http://api.twitter.com/1/statuses/mentions.json");

    //        var requestParameters = new SortedDictionary();
    //        requestParameters.Add("count", count.ToString());
    //        requestParameters.Add("include_entities", "true");


    //        var response = GetResponse(resourceUrl, Method.GET, requestParameters);

    //        return response;
    //    }

    //    public string GetTweets(string screenName, int count)
    //    {
    //        string resourceUrl =
    //            string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json");

    //        var requestParameters = new SortedDictionary();
    //        requestParameters.Add("count", count.ToString());
    //        requestParameters.Add("screen_name", screenName);

    //        var response = GetResponse(resourceUrl, Method.GET, requestParameters);

    //        return response;
    //    }

    //    public string PostStatusUpdate(string status, double latitude, double longitude)
    //    {
    //        const string resourceUrl = "http://api.twitter.com/1/statuses/update.json";

    //        var requestParameters = new SortedDictionary();
    //        requestParameters.Add("status", status);
    //        requestParameters.Add("lat", latitude.ToString());
    //        requestParameters.Add("long", longitude.ToString());

    //        return GetResponse(resourceUrl, Method.POST, requestParameters);
    //    }

    //    private string GetResponse
    //    (string resourceUrl, Method method, SortedDictionary requestParameters)
    //    {
    //        ServicePointManager.Expect100Continue = false;
    //        WebRequest request = null;
    //        string resultString = string.Empty;

    //        if (method == Method.POST)
    //        {
    //            var postBody = requestParameters.ToWebString();

    //            request = (HttpWebRequest)WebRequest.Create(resourceUrl);
    //            request.Method = method.ToString();
    //            request.ContentType = "application/x-www-form-urlencoded";

    //            using (var stream = request.GetRequestStream())
    //            {
    //                byte[] content = Encoding.ASCII.GetBytes(postBody);
    //                stream.Write(content, 0, content.Length);
    //            }
    //        }
    //        else if (method == Method.GET)
    //        {
    //            request = (HttpWebRequest)WebRequest.Create(resourceUrl + "?"
    //                + requestParameters.ToWebString());
    //            request.Method = method.ToString();
    //        }
    //        else
    //        {
    //            //other verbs can be addressed here...
    //        }

    //        if (request != null)
    //        {
    //            var authHeader = CreateHeader(resourceUrl, method, requestParameters);
    //            request.Headers.Add("Authorization", authHeader);
    //            var response = request.GetResponse();

    //            using (var sd = new StreamReader(response.GetResponseStream()))
    //            {
    //                resultString = sd.ReadToEnd();
    //                response.Close();
    //            }
    //        }

    //        return resultString;
    //    }

    //    private string CreateOauthNonce()
    //    {
    //        return Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
    //    }

    //    private string CreateHeader(string resourceUrl, Method method,
    //                                SortedDictionary requestParameters)
    //    {
    //        var oauthNonce = CreateOauthNonce();
    //        // Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
    //        var oauthTimestamp = CreateOAuthTimestamp();
    //        var oauthSignature = CreateOauthSignature
    //        (resourceUrl, method, oauthNonce, oauthTimestamp, requestParameters);

    //        //The oAuth signature is then used to generate the Authentication header. 
    //        const string headerFormat = "OAuth oauth_nonce=\"{0}\", 
    //                                    oauth_signature_method =\"{1}\", " +
    //                                     "oauth_timestamp=\"{2}\", 
    //                                    oauth_consumer_key =\"{3}\", " +
    //                                     "oauth_token=\"{4}\", 
    //                                    oauth_signature =\"{5}\", " +
    //                                     "oauth_version=\"{6}\"";

    //        var authHeader = string.Format(headerFormat,
    //                                       Uri.EscapeDataString(oauthNonce),
    //                                       Uri.EscapeDataString(OauthSignatureMethod),
    //                                       Uri.EscapeDataString(oauthTimestamp),
    //                                       Uri.EscapeDataString(ConsumerKey),
    //                                       Uri.EscapeDataString(AccessToken),
    //                                       Uri.EscapeDataString(oauthSignature),
    //                                       Uri.EscapeDataString(OauthVersion)
    //            );

    //        return authHeader;
    //    }

    //    private string CreateOauthSignature
    //    (string resourceUrl, Method method, string oauthNonce, string oauthTimestamp,
    //                                        SortedDictionary requestParameters)
    //    {
    //        //firstly we need to add the standard oauth parameters to the sorted list
    //        requestParameters.Add("oauth_consumer_key", ConsumerKey);
    //        requestParameters.Add("oauth_nonce", oauthNonce);
    //        requestParameters.Add("oauth_signature_method", OauthSignatureMethod);
    //        requestParameters.Add("oauth_timestamp", oauthTimestamp);
    //        requestParameters.Add("oauth_token", AccessToken);
    //        requestParameters.Add("oauth_version", OauthVersion);

    //        var sigBaseString = requestParameters.ToWebString();

    //        var signatureBaseString = string.Concat
    //        (method.ToString(), "&", Uri.EscapeDataString(resourceUrl), "&",
    //                            Uri.EscapeDataString(sigBaseString.ToString()));

    //        //Using this base string, we then encrypt the data using a composite of the 
    //        //secret keys and the HMAC-SHA1 algorithm.
    //        var compositeKey = string.Concat(Uri.EscapeDataString(ConsumerKeySecret), "&",
    //                                         Uri.EscapeDataString(AccessTokenSecret));

    //        string oauthSignature;
    //        using (var hasher = new HMACSHA1(Encoding.ASCII.GetBytes(compositeKey)))
    //        {
    //            oauthSignature = Convert.ToBase64String(
    //                hasher.ComputeHash(Encoding.ASCII.GetBytes(signatureBaseString)));
    //        }

    //        return oauthSignature;
    //    }

    //    private static string CreateOAuthTimestamp()
    //    {

    //        var nowUtc = DateTime.UtcNow;
    //        var timeSpan = nowUtc - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    //        var timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

    //        return timestamp;
    //    }
    //}

    //public enum Method
    //{
    //    POST,
    //    GET
    //}

    //public static class Extensions
    //{
    //    public static string ToWebString(this SortedDictionary source)
    //    {
    //        var body = new StringBuilder();

    //        foreach (var requestParameter in source)
    //        {
    //            body.Append(requestParameter.Key);
    //            body.Append("=");
    //            body.Append(Uri.EscapeDataString(requestParameter.Value));
    //            body.Append("&");
    //        }
    //        //remove trailing '&'
    //        body.Remove(body.Length - 1, 1);

    //        return body.ToString();
    //    }
    //}


    public class twitter
    {
        private static string _oauth_token = ConfigurationManager.AppSettings["twitter_user_token"];
        private static string _oauth_token_secret = ConfigurationManager.AppSettings["twitter_user_secret"];
        private static string _oauth_consumer_key = ConfigurationManager.AppSettings["twitter_consumer_key"];
        private static string _oauth_consumer_secret = ConfigurationManager.AppSettings["twitter_consumer_secret"];

        private static string _oauth_version = "1.0";
        private static string _oauth_signature_method = "HMAC-SHA1";
        private static string _oauth_nonce = Convert.ToBase64String(
                                         new ASCIIEncoding().GetBytes(
                                               DateTime.Now.Ticks.ToString()));
        private static string _WOEID { get; set; }
        public twitter(string WOEID)
        {
            _WOEID = WOEID;


        }

        public void GetTrending()
        {
            var timeSpan = DateTime.UtcNow
                                         - new DateTime(1970, 1, 1, 0, 0, 0, 0,
                                              DateTimeKind.Utc);
            var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();
            var resource_url = "https://api.twitter.com/1.1/trends/place.json?id=" +_WOEID;
            //var status = "Updating status via REST API if this works";
            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}";
            var oauth_signature_method = "HMAC-SHA1";
            //Check this order
            var baseString = string.Format(baseFormat,
                                        _oauth_consumer_key,
                                        _oauth_nonce,
                                        _oauth_signature_method,
                                        oauth_timestamp,
                                        _oauth_token,
                                        _oauth_version
                                        
                                        );
            var requesType = "GET";
            baseString = string.Concat(requesType.ToUpper(),"&", Uri.EscapeDataString(resource_url),
                         "&", Uri.EscapeDataString(baseString));
            var compositeKey = string.Concat(Uri.EscapeDataString(_oauth_consumer_secret),
                        "&", Uri.EscapeDataString(_oauth_token_secret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                    hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
            }

            var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
                   "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
                   "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
                   "oauth_version=\"{6}\"";
            
            var authHeader = string.Format(headerFormat,
                        Uri.EscapeDataString(_oauth_nonce),
                        Uri.EscapeDataString(oauth_signature_method),
                        Uri.EscapeDataString(oauth_timestamp),
                        Uri.EscapeDataString(_oauth_consumer_key),
                        Uri.EscapeDataString(_oauth_token),
                        Uri.EscapeDataString(oauth_signature),
                        Uri.EscapeDataString(_oauth_version)
                );

            //var postBody = "status=" + Uri.EscapeDataString(status);

            ServicePointManager.Expect100Continue = false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Headers.Add("Accept-Encoding", "gzip");

            //var stream = request.GetRequestStream();
            var response = (HttpWebResponse)request.GetResponse();
            //using (Stream stream = request.GetRequestStream())
            //{
            //    //byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
            //    //stream.Write(content, 0, content.Length);
            //     WebResponse response = request.GetResponse();
            //}


        }


       
    }

}
