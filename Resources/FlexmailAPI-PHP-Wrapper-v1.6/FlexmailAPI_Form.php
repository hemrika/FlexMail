<?php

class FlexmailAPI_Form extends Flexmail_API
{
    /**
     * Return list of all forms in a Flexmail account
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     * );
     * 
     * @return forms
     */
    public function getAll()
    {
        $request = null;
        
        $response = $this->execute("GetForms", $request);
        return FlexmailAPI::stripHeader($response);
    }
     
    /**
     * Return list of all user submitted date for a given form and optionally 
     * a campaign
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     *     "formId"     =>  12345, //int mandatory
     *     "campaignId" =>  12345,  /int optional
     * );
     * 
     * @param Array $parameters Associative array with formId and optional 
     *               campaignId
     * 
     * @return formdata
     */
    public function getResults($parameters)
    {
        $request = array();
        
        foreach($parameters as $key => $value):
            $request[$key] = $value;            
        endforeach;        
        
        $response = $this->execute("GetFormResults", $request);

        return FlexmailAPI::stripHeader($response);
     }
}