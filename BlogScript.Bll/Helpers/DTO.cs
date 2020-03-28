using BlogScript.Bll.Concreate;
using BlogScript.Core.Concreate.Entities;
using BlogScript.Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BlogScript.Bll.Helpers
{
    public static class DTO
    {
        public static void UserToSession(this User user, ref SessionUser session)
        {
            var UserType = user.GetType();
            var SessionType = session.GetType();

            var UserProps = UserType.GetProperties();
            var SessionProps = SessionType.GetProperties();

            foreach (var sP in SessionProps)
                foreach (var uP in UserProps)
                    if (sP.Name.Equals(uP.Name) && sP.PropertyType.Equals(uP.PropertyType) && sP.CanWrite)
                        sP.SetValue(session, uP.GetValue(user));
        }

    }
}
