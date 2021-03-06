<?php

class FlexmailAPI_Group extends FlexmailAPI
{
    /**
     * Create a new Group
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     *      "groupType" => array (             // array mandatory
     *          "groupName" => "My group name" // string mandatory
     *      )   
     * );
     * 
     * @param Array $parameters Associative array with properties of a groupType
     *                          object
     * 
     * @return groupId
     */
    public function create ($parameters)
    {   
        $request = FlexmailAPI::parseArray($parameters);
        
        $response = $this->execute("CreateGroup", $request);
        return FlexmailAPI::stripHeader($response);
    }
     
    /**
     * Update a Group
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     *      "groupType" => array (        // array mandatory
     *          "groupId"   => 123456     // int mandatory
     *          "groupName" => "My group" // string mandatory
     *      )
     * );
     * 
     * @param Array $parameters Associative array with properties of a groupType
     *                          object
     * 
     * @return void
     */
    public function update ($parameters)
    {
        $request = FlexmailAPI::parseArray($parameters);

        $response = $this->execute("UpdateGroup", $request);
        return FlexmailAPI::stripHeader($response);
        
    }

    /**
     * Delete a Group
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     *      "groupType" => array (    // array mandatory
     *          "groupId"   => 123456 // int mandatory
     *      )
     * );
     * 
     * @param Array $parameters Associative array with properties of a groupType
     *              object
     * 
     * @return void
     */
    public function delete ($parameters)
    {
        $request = FlexmailAPI::parseArray($parameters);
        
        $response = $this->execute("DeleteGroup", $request);
        return FlexmailAPI::stripHeader($response);
        
    }

    /**
     * Get all Groups
     * 
     * @return groupTypetItems array
     */
    public function getAll ()
    {
        $request = null; 
        $response = $this->execute("GetGroups", $request);
        return FlexmailAPI::stripHeader($response);
        
    }
 
    /**
     * Create a new GroupSubscription
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     *      "groupSubscriptionType" => array (     // array mandatory
     *          "groupId"                 => 27091,       // int mandatory
     *          "emailAddressFlexmailId"  => 31655,       // int mandatory (unless referenceId is set)
     *          "emailAddressReferenceId" => "my-ref-001" // string mandatory (unless flexmailId is set)
     *      )
     * );
     * 
     * @param Array $parameters Associative array with properties of a groupSubscriptionType object
     * 
     * @return groupSubscriptionId
     */
    public function createSubscription ($parameters)
    {   
        $request = FlexmailAPI::parseArray($parameters);
       
        $response = $this->execute("CreateGroupSubscription", $request);
        return FlexmailAPI::stripHeader($response);
    }
     
    /**
     * delete a GroupSubscription
     * 
     * Parmeters example:
     * ------------------
     * $parameters = array (
     *      "groupSubscriptionType" => array (     // array mandatory
     *          "groupId"                 => 27091,       // int mandatory
     *          "emailAddressFlexmailId"  => 31655,       // int mandatory (unless referenceId is set)
     *          "emailAddressReferenceId" => "my-ref-001" // string mandatory (unless flexmailId is set)
     *      )
     * );
     * 
     * @param Array $parameters Associative array with properties of an groupSubscriptionType object
     * 
     * @return void
     */
    public function deleteSubscription ($parameters)
    {
        $request = FlexmailAPI::parseArray($parameters);
        
        $response = $this->execute("DeleteGroupSubscription", $request);
        return FlexmailAPI::stripHeader($response);
        
    }
}