<?php

class FlexmailAPI_List extends FlexmailAPI
{   
    /**
     * Create a new Mailinglist
     * 
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     *      "categoryId"          => 38916,     // int mandatory
     *      "mailingListName"     => "My List", // string mandatory
     *      "mailingListLanguage" => "FR",      // sring mandatory
     * );
     * 
     * @param Array $parameters Associative array with name of the new 
     *                          mailinglist, categoryId and language
     * 
     * @return mailingListId
     */
    public function create ($parameters)
    {
        
        $request = FlexmailAPI::parseArray($parameters);
        
        $response = $this->execute("CreateMailingList", $request);
        return FlexmailAPI::stripHeader($response);
    }

    /**
     * Update a Mailinglist
     * 
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     *      "mailingListId"       => 110138,     // int mandatory
     *      "mailingListName"     => "My List", // string mandatory
     *      "mailingListLanguage" => "FR",      // sring mandatory
     * );
     * 
     * @param Array $parameters Associative array with mailingListName, 
     *                          mailingListId, categoryId and language
     * 
     * @return void
     */
    public function update ($parameters)
    {
        $request = FlexmailAPI::parseArray($parameters);
        
        $response = $this->execute("UpdateMailingList", $request);
        return FlexmailAPI::stripHeader($response);
        
    }

    /**
     * Delete a Mailinglist
     * 
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     *      "mailingListId" => 110138 // int mandatory
     * );
     * 
     * @param Array $parameters Associative array with mailingListId
     * 
     * @return void
     */
    public function delete ($parameters)
    {
        $request = FlexmailAPI::parseArray($parameters);
        
        $response = $this->execute("DeleteMailingList", $request);
        return FlexmailAPI::stripHeader($response);
    }

    /**
     * Get all Mailinglists within a Category
     * 
     * @param Array $parameters Associative array with categoryId
     * 
     * @return mailingListTypeItems array
     */
    public function getAll ($parameters)
    {
        $request = FlexmailAPI::parseArray($parameters);
        
        $response = $this->execute("GetMailingLists", $request);
        return FlexmailAPI::stripHeader($response);
     }
}