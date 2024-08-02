using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;

namespace PreRegistration.Models.Helpers
{
    public class SearchADGroups
    {
        public class WinUserEntity
        {
            public string Name { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public List<WindowsGroups> MemberOf { get; set; }

        }
        public class WindowsGroups
        {
            public string Name { get; set; }
            public string DisplayName { get; set; }
        }

        public string SearchAD(string userId)
        {
            Logger _log = new Logger();
            _log.Log("SearchAD - UserId: " + userId);
            //userId = "joneli5";
            //userId = "wilsbr6";
            string userGroup = null;
            string userIdLower = userId.ToLower();
            if (userIdLower != null) userId = userIdLower;

            SearchADGroups searchADGroups = new SearchADGroups();
            //userGroup = "NoAccess";
            bool InADGroup = false;
            UserPrincipal useridentity = UserPrincipal.FindByIdentity(new PrincipalContext(ContextType.Domain, Environment.UserDomainName), IdentityType.SamAccountName, userId);

            foreach (GroupPrincipal group in useridentity.GetGroups())
            {
                if (!InADGroup)
                {
                    switch (group.Name)
                    {
                        case "TMWebApplications-Admin":
                            userGroup = "Admin";
                            InADGroup = true;
                            break;
                        case "PrePlaceScreenNHEH-Admin":
                            userGroup = "Admin";
                            InADGroup = true;
                            break;
                        case "PrePlaceScreenNHEH-Contributor":
                            userGroup = "Contributor";
                            InADGroup = true;
                            break;
                        case "PrePlaceScreenNHEH-Reader":
                            userGroup = "ReadOnly";
                            InADGroup = true;
                            break;
                        default:
                            userGroup = "NoAccess";
                            break;
                    }
                }
            }

            return userGroup;
        }
    }
}
