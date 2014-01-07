/**
 * Created by maurooliveira on 1/1/14.
 */

import org.apache.http.*;
import org.apache.http.client.methods.*;
import org.apache.http.entity.ContentType;
import org.apache.http.entity.StringEntity;
import org.apache.http.impl.client.*;
import org.apache.http.util.EntityUtils;
import java.io.IOException;

public class LanguageHttpClient
{
    private final String HOST = "http://192.168.1.13/MvcWebApi/api/languages/";
    private final CloseableHttpClient httpclient = HttpClients.createDefault();

    private void PrintResponse(HttpResponse response) throws IOException
    {
        String statusCode = Integer.toString(response.getStatusLine().getStatusCode());
        String status = response.getStatusLine().getReasonPhrase();

        System.out.println(statusCode.concat(" - ").concat(status));

        HeaderIterator it = response.headerIterator();

        while(it.hasNext())
        {
            System.out.println(it.next());
        }

        HttpEntity entity = response.getEntity();

        if (entity != null)
        {
            if (entity.getContentLength() > 0)
            {
                System.out.println(EntityUtils.toString(entity));
            }
        }
    }

    public void Post(String newValue)  throws IOException
    {
        HttpPost httpPost = new HttpPost(HOST);
        String JSONString = "\"".concat(newValue).concat("\"");
        StringEntity stringEntity = new StringEntity(JSONString, ContentType.APPLICATION_JSON);
        httpPost.setEntity(stringEntity);

        CloseableHttpResponse response = httpclient.execute(httpPost);
        try
        {
            PrintResponse(response);
        }
        finally
        {
            response.close();
        }
    }

    public void Put(String value, int index) throws IOException
    {
        HttpPut httpPut;
        httpPut = new HttpPut(HOST.concat(Integer.toString(index)));
        String JSONString = "\"".concat(value).concat("\"");
        StringEntity stringEntity = new StringEntity(JSONString, ContentType.APPLICATION_JSON);
        httpPut.setEntity(stringEntity);

        CloseableHttpResponse response;
        response = httpclient.execute(httpPut);
        try
        {
            PrintResponse(response);
        }
        finally
        {
            response.close();
        }
    }

    public void Delete(int index) throws IOException
    {
        HttpDelete httpDelete = new HttpDelete(HOST.concat(Integer.toString(index)));

        CloseableHttpResponse response = httpclient.execute(httpDelete);
        try
        {
            PrintResponse(response);
        }
        finally
        {
            response.close();
        }
    }

    public void GetAll() throws IOException
    {
        HttpGet httpGet = new HttpGet(HOST);
        CloseableHttpResponse response;
        response = httpclient.execute(httpGet);
        try
        {
            PrintResponse(response);
        }
        finally
        {
            response.close();
        }
    }

    public void GetItem(int index) throws IOException
    {
        HttpGet httpGet = new HttpGet(HOST.concat(Integer.toString(index)));
        CloseableHttpResponse response;
        response = httpclient.execute(httpGet);
        try
        {
            PrintResponse(response);
        }
        finally
        {
            response.close();
        }
    }


}
