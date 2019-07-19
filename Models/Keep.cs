using System.Collections.Generic;

namespace keepr.Models
{
    public class Keep
    {
        int id {get;set;}
string Name {get;set;}
string Description {get;set;}
string UserId {get;set;}
string Image {get;set;}
bool IsPrivate {get;set;}
int Views {get;set;}
int Shares {get;set;}
IEnumerable<Keep> Keeps{get;set;}
    }
}