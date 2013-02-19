using System;
using System.Collections.Generic;
using System.Linq;
using KRS.Model.Users;

namespace KRS.DataAccess.SampleData
{
    public static class UsersCollection
    {
        public static List<KRSUser> _theChosen;
        private static KRSUser 
            _johnPapa, _danWahlin, _wardBell, _hansFjallemark, 
            _jimCowart, _ryanNiemeyer, _scottGuthrie, _steveSanderson, 
            _aaronSkonnard, _fritzOnion, _scottHunter, _howardDierking, 
            _madsKristensen, _elijahManor, _johnSmith, _estebanGarcia,
            _shawnWildermuth, _peteBrown, _timHeuer, _julieLerman,
            _scottHanselman, _glennBlock, _jesseLiberty, _ericBarnard,
            _daveWard, _mikeCallaghan;

        /// <summary>Add the Chosen people</summary>
        public static void AddKRSUsers(List<KRSUser> KRSUsers)
        {
            _theChosen = new List<KRSUser>();

            _theChosen.Add(_johnPapa = new KRSUser
            {
                FirstName = "John",
                LastName = "Papa",
                Email = "johnp@contoso.com",
                Blog = "http://johnp.contoso.com",
                Twitter = "@john_papa",
                Gender = "M",
                Bio = "Husband, father, and Catholic enjoying every minute with my family. Microsoft Regional Director, Evangelist, speaker, author, and Pluralsight trainer.",
            });
            _theChosen.Add(_danWahlin =new KRSUser
            {
                FirstName = "Dan",
                LastName = "Wahlin",
                Email = "danw@contoso.com",
                Blog = "http://danw.contoso.com",
                Twitter = "@danwahlin",
                Gender = "M",
                Bio = "Chief Architect at Wahlin Consulting. Provide consulting & training on jQuery, HTML5, ASP.NET, SharePoint. Husband & father, like to write and record music.",
            });
            _theChosen.Add(_wardBell = new KRSUser
            {
                FirstName = "Ward",
                LastName = "Bell",
                Email = "wardb@contoso.com",
                Blog = "http://wardb.contoso.com",
                Twitter = "@wardbell",
                Gender = "M",
                Bio = "V.P. of Technology at IdeaBlade. Speaks often on client application development issues to anyone who will listen. Likes sociology, history, poetry, and ridiculous clothes.",
            });
            _theChosen.Add(_hansFjallemark = new KRSUser
            {
                FirstName = "Hans",
                LastName = "Fjällemark",
                Email = "hansf@contoso.com",
                Blog = "http://hansf.contoso.com",
                Twitter = "@hfjallemark",
                Gender = "M",
                Bio = "Freelancing developer & designer based in Sweden. I spend most of my time implementing usable and attractive UX in HTML5 or Silverli.. no wait, just HTML5:) ",
            });
            _theChosen.Add(_jimCowart = new KRSUser
            {
                FirstName = "Jim",
                LastName = "Cowart",
                Email = "jimc@contoso.com",
                Blog = "http://jimc.contoso.com",
                Twitter = "@ifandelse",
                Gender = "M",
                Bio = "Husband, father, architect, developer, tea drinker. Opinions are my own. Unless they're good",
            });
            _theChosen.Add(_ryanNiemeyer = new KRSUser
            {
                FirstName = "Ryan",
                LastName = "Niemeyer",
                Email = "ryann@contoso.com",
                Blog = "http://ryann.contoso.com/",
                Twitter = "@rpniemeyer",
                Gender = "M",
                Bio = "Coder, tester, father, and husband. Never short on ideas. Love to learn and collaborate.",
            });
            _theChosen.Add(_scottGuthrie = new KRSUser
            {
                FirstName = "Scott",
                LastName = "Guthrie",
                Email = "scottg@contoso.com",
                Blog = "http://scottg.contoso.com",
                Twitter = "@scottgu",
                Gender = "M",
                Bio = "I live in Seattle and build a few products for Microsoft",
            });
            _theChosen.Add(_steveSanderson = new KRSUser
            {
                FirstName = "Steve",
                LastName = "Sanderson",
                Email = "steves@contoso.com",
                Blog = "http://steves.contoso.com",
                Twitter = "@stevensanderson",
                Gender = "M",
                Bio = "Also known as Steven Sanderson",
            });
            _theChosen.Add(_aaronSkonnard = new KRSUser
            {
                FirstName = "Aaron",
                LastName = "Skonnard",
                Email = "aarons@contoso.com",
                Blog = "http://aarons.contoso.com",
                Twitter = "@skonnard",
                Gender = "M",
                Bio = "Changing the way software professionals learn. President/CEO of Pluralsight.",
            });
            _theChosen.Add(_fritzOnion = new KRSUser
            {
                FirstName = "Fritz",
                LastName = "Onion",
                Email = "fritzo@contoso.com",
                Blog = "http://fritzo.contoso.com",
                Twitter = "",
                Gender = "M",
                Bio = "A co-founder of Pluralsight where he serves as the Editor in Chief.",
            });
            _theChosen.Add(_johnSmith = new KRSUser
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "johns@contoso.com",
                Blog = "http://johns.contoso.com",
                Twitter = "@onefloridacoder",
                Gender = "M",
                Bio = "Christian .NET Dev & Orlando .NET User Group VP; 4,5,6-string bass player.",
            });
            _theChosen.Add(_scottHunter = new KRSUser
            {
                FirstName = "Scott",
                LastName = "Hunter",
                Email = "scotth@contoso.com",
                Blog = "http://scotth.contoso.com",
                Twitter = "@coolcsh",
                Gender = "M",
                Bio = "Program Manager at Microsoft on web technologies such as Azure, ASP.NET, MVC, Web API, Entity Framework, NuGet and more...",
            });
            _theChosen.Add(_madsKristensen = new KRSUser
            {
                FirstName = "Mads",
                LastName = "Kristensen",
                Email = "madsk@contoso.com",
                Blog = "http://madsk.contoso.com",
                Twitter = "@mkristensen",
                Gender = "M",
                Bio = "Program Manager for Microsoft Web Platform & Tools and founder of BlogEngine.NET",
            });
            _theChosen.Add(_howardDierking = new KRSUser
            {
                FirstName = "Howard",
                LastName = "Dierking",
                Email = "howardd@contoso.com",
                Blog = "http://howardd.contoso.com",
                Twitter = "@howard_dierking",
                Gender = "M",
                Bio = "I like technology...a lot...",
            });
            _theChosen.Add(_elijahManor = new KRSUser
            {
                FirstName = "Elijah",
                LastName = "Manor",
                Email = "elijahm@contoso.com",
                Blog = "http://elijiahm.contoso.com",
                Twitter = "@elijahmanor",
                Gender = "M",
                Bio = "I am a Christian and a family man. I develops at appendTo as a Senior Architect providing corporate jQuery support, training, and consulting.",
            });
            _theChosen.Add(_estebanGarcia = new KRSUser
            {
                FirstName = "Esteban",
                LastName = "Garcia",
                Email = "estebang@contoso.com",
                Blog = "http://estebang.contoso.com",
                Twitter = "@EstebanFGarcia",
                Gender = "M",
                Bio = "TFS | Visual Studio ALM Ranger | Scrum | .NET Development | Solutions Architect at @AgileThought | @ONETUG President | UCF Knight",
            });
            _theChosen.Add(_shawnWildermuth = new KRSUser
            {
                FirstName = "Shawn",
                LastName = "Wildermuth",
                Email = "shawnw@contoso.com",
                Blog = "http://shawnw.contoso.com",
                Twitter = "@ShawnWildermuth",
                Gender = "M",
                Bio = "Author, trainer, software guy, Braves fan, guitar player, Xbox maven, coffee addict and astronomy fan.",
            });
            _theChosen.Add(_peteBrown = new KRSUser
            {
                FirstName = "Pete",
                LastName = "Brown",
                Email = "peteb@contoso.com",
                Blog = "http://peteb.contoso.com",
                Twitter = "@Pete_Brown",
                Gender = "M",
                Bio = "Microsoft XAML and blinky lights guy. Father of two, author, woodworker, C64.",
            });
            _theChosen.Add(_timHeuer = new KRSUser
            {
                FirstName = "Tim",
                LastName = "Heuer",
                Email = "timh@contoso.com",
                Blog = "http://timh.contoso.com",
                Twitter = "@timheuer",
                Gender = "M",
                Bio = "I work on XAML client platforms at Microsoft and trying to be the best dad/husband I can be when I'm not working.",
            });
            _theChosen.Add(_julieLerman = new KRSUser
            {
                FirstName = "Julie",
                LastName = "Lerman",
                Email = "juliel@contoso.com",
                Blog = "http://juliel.contoso.com",
                Twitter = "@julielerman",
                Gender = "F",
                Bio = "Vermont Geekette, .NET (and Entity Framework) Mentor/Consultant, Author, MS MVP, INETA Speaker, Vermont.NET User Group Leader",
            });
            _theChosen.Add(_glennBlock = new KRSUser
            {
                FirstName = "Glenn",
                LastName = "Block",
                Email = "glennb@contoso.com",
                Blog = "http://glennb.contoso.com",
                Twitter = "@gblock",
                Gender = "M",
                Bio = "Father, Husband, Spiritualist, Software geek, Change agent, REST Head",
            });
            _theChosen.Add(_scottHanselman = new KRSUser
            {
                FirstName = "Scott",
                LastName = "Hanselman",
                Email = "shanselman@contoso.com",
                Blog = "http://shanselman.contoso.com",
                Twitter = "@shanselman",
                Gender = "M",
                Bio = "Tech, Diabetes, Parenting, Race, Linguistics, Fashion, Podcasting, Open Source, Culture, Code, Ratchet, Phony.",
            });
            _theChosen.Add(_jesseLiberty = new KRSUser
            {
                FirstName = "Jesse",
                LastName = "Liberty",
                Email = "jliberty@contoso.com",
                Blog = "http://jliberty.contoso.com",
                Twitter = "@JesseLiberty",
                Gender = "M",
                Bio = "Telerik XAML Evangelist",
            });
            _theChosen.Add(_ericBarnard = new KRSUser
            {
                FirstName = "Eric",
                LastName = "Barnard",
                Email = "ebarnard@contoso.com",
                Blog = "http://ebarnard.contoso.com",
                Twitter = "@EricBarnard",
                Gender = "M",
                Bio = "Technologist and Entrepreneur trying to find my where my path and the world's needs cross",
            });
            _theChosen.Add(_daveWard = new KRSUser
            {
                FirstName = "Dave",
                LastName = "Ward",
                Email = "dward@contoso.com",
                Blog = "http://dward.contoso.com",
                Twitter = "@encosia",
                Gender = "M",
                Bio = "Microsoft Regional Director",
            });

            _theChosen.Add(_mikeCallaghan = new KRSUser
            {
                FirstName = "Mike",
                LastName = "Callaghan",
                Email = "mcallaghan@contoso.com",
                Blog = "http://mcallaghan.contoso.com",
                Twitter = "@walkingriver",
                Gender = "M",
                Bio = "Mike has been developing software professionally since 1995, primarily in Microsoft environments.",
            });
            

            //_theChosen.ForEach(p => p.ImageSource = 
              //  (p.FirstName + "_" + p.LastName + ".jpg").ToLowerInvariant());

            //_hansFjallemark.ImageSource = "hans_fjallemark.jpg"; // get rid of 'ä'

            KRSUsers.AddRange(_theChosen);
        }
    }
}
