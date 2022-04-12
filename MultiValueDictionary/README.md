# MutliValueDictionary
A console application that works with a multi-value dictionary of string key and List&lt;string> Values.

# App Overview

A basic console app built on .NETCore 5.0.
A generic multi-value dictionary. Current primarily support strings for values and keys. Can easily be extended to add support
for other class types.

Methods

ADD - Adds key and member to dictionary one at a time.
MethodStructure - ADD Key Value

REMOVE - Removes a member from specified key. If member removed is the last member the key will be removed as well.
MethodStructure - REMOVE Key Value

REMOVEALL - Removes all members and key for specified key.
MethodStructure - REMOVEALL Key

CLEAR - Removes all keys and members from dictionary.
MethodStructure - CLEAR

KEYS - Returns all keys in the dictionary
MethodStructure - KEYS

KEYEXISTS - Returns bool representing if key exists.
MethodStructure - KEYEXISTS Key

MEMBERS - Returns the members for specified key.
MethodStructure - MEMBERS Key

ALLMEMBERS - Returns all members in the dictionary. 
MethodStructure ALLMEMBERS

MEMBEREXISTS - Returns bool representing if a member exists with matching key.
MethodStructure - MEMBEREXISTS Key Value

ITEMS - Return all keys and members of the dictionary.
MethodStructure - ITEMS

# Build
  
  dotnet build -p:Version=1.0 incremeting build by .1 each time

# Run

`dotnet run`
