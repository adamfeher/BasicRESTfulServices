using NUnit.Framework;
using BasicRESTfulServices.ReqRes.Calls;
using BasicRESTfulServices.ReqRes.JsonObjects;
using System.Collections.Generic;
using System.Net.Http;

namespace BasicRESTfulServices
{
    [TestFixture]
    public class BasicTests
    {
        // Most of the sample tests below follow a more encapsulated approach towards automated test design.
        // This allows for some maintanence to be performed at a location in a lower level than the written test cases.

        // This was the approach followed throughout my experience most recently, though the HTTPClient can be 
        // left exposed and directly used at the test case definition layer as well.
        // This approach could be favored if some of the test case writers would not do well with too much 
        // complexity at the test case design level.

        [Test]
        public void ListUserPageSizeCanBeDynamic()
        {
            List<User> sizeThree = Users.ListMultiple(2, 3);
            List<User> sizeFour = Users.ListMultiple(1, 4);
            Assert.AreEqual(3, sizeThree.Count);
            Assert.AreEqual(4, sizeFour.Count);
        }

        [Test]
        public void ListUsersNotDuplicatedWhenPaginated()
        {
            HashSet<int> returnedIDs = new HashSet<int>();
            List<User> pageOne = Users.ListMultiple(1, 6);
            List<User> pageTwo = Users.ListMultiple(2, 6);
            Assert.IsTrue(pageOne.TrueForAll(user => returnedIDs.Add(user.id)));
            Assert.IsTrue(pageTwo.TrueForAll(user => returnedIDs.Add(user.id)));
        }

        [Test]
        public void ListSingleUserByIdAndCheckNonEmptyLastName()
        {
            User user = Users.ListSingle(2);
            Assert.IsNotEmpty(user.lastName);
        }

        [Test]
        public void ListedResourcesAllHaveNonEmptyPantoneValues()
        {
            List<Resource> allResources = Resources.ListMultiple(1, 12);
            Assert.IsTrue(allResources.TrueForAll(r => !string.IsNullOrEmpty(r.extras["pantone_value"].ToString())));
        }

        
        [Test]
        public void UserNotFound()
        {
            // The encapsulated design does not easily allow for specific error code checking within the response
            // without also adding an error handling system, a feature which to be updated for this sample.
            User user = Users.ListSingle(24);
            Assert.IsNull(user);
        }
    }
}
