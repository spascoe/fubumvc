using System;
using System.Collections.Generic;
using System.Linq;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.ObjectGraph;
using FubuMVC.Core.View;
using FubuMVC.Core.View.Attachment;
using FubuMVC.Tests.View.FakeViews;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.Tests.View
{
    [TestFixture]
    public class when_filtering_views_by_viewmodel_type_and_namespace_and_name
    {
        [SetUp]
        public void SetUp()
        {
            token = new FakeViewToken
            {
                Name = "AAction",
                Folder = GetType().Namespace,
                ViewType =  typeof(AAction),
                ViewModelType = typeof (ViewModel1)
            };
            var views = new List<IViewToken>
            {
                token
            };

            bag = new ViewBag(views);

            filter = new ActionWithSameNameAndFolderAsViewReturnsViewModelType();
        }

        private FakeViewToken token;
        private ViewBag bag;
        private ActionWithSameNameAndFolderAsViewReturnsViewModelType filter;

        [Test]
        public void everything_matches()
        {
            ActionCall action = ActionCall.For<ViewsForActionFilterTesterController>(x => x.AAction());
            filter.Apply(action, bag).First().ShouldBeTheSameAs(token);
        }

        [Test]
        public void only_name_and_namespace_match()
        {
            ActionCall action = ActionCall.For<ViewsForActionFilterTesterController>(x => x.AAction());
            token.ViewModelType = typeof (ViewModel2);

            filter.Apply(action, bag).Count().ShouldEqual(0);
        }

        [Test]
        public void only_type_and_name_match()
        {
            ActionCall action = ActionCall.For<ViewsForActionFilterTesterController>(x => x.AAction());
            token.Folder = Guid.NewGuid().ToString();

            filter.Apply(action, bag).Count().ShouldEqual(0);
        }

        [Test]
        public void only_type_and_namespace_match()
        {
            ActionCall action = ActionCall.For<ViewsForActionFilterTesterController>(x => x.AAction());
            token.Name = "something different";

            filter.Apply(action, bag).Count().ShouldEqual(0);
        }
    }

    [TestFixture]
    public class when_filtering_views_by_viewmodel_type_and_namespace
    {
        [SetUp]
        public void SetUp()
        {
            token = new FakeViewToken
            {
                Name = "A",
                Folder = GetType().Namespace,
                ViewType = typeof(FakeViewToken),
                ViewModelType = typeof (ViewModel1)
            };
            var views = new List<IViewToken>
            {
                token
            };

            bag = new ViewBag(views);

            filter = new ActionInSameFolderAsViewReturnsViewModelType();
        }

        private FakeViewToken token;
        private ViewBag bag;
        private ActionInSameFolderAsViewReturnsViewModelType filter;

        [Test]
        public void everything_matches()
        {
            ActionCall action = ActionCall.For<ViewsForActionFilterTesterController>(x => x.AAction());
            filter.Apply(action, bag).First().ShouldBeTheSameAs(token);
        }

        [Test]
        public void only_name_and_namespace_match()
        {
            ActionCall action = ActionCall.For<ViewsForActionFilterTesterController>(x => x.AAction());
            token.ViewModelType = typeof (ViewModel2);

            filter.Apply(action, bag).Count().ShouldEqual(0);
        }

        [Test]
        public void only_type_and_name_match()
        {
            ActionCall action = ActionCall.For<ViewsForActionFilterTesterController>(x => x.AAction());
            token.Folder = Guid.NewGuid().ToString();

            filter.Apply(action, bag).Count().ShouldEqual(0);
        }

        [Test]
        public void only_type_and_namespace_match()
        {
            ActionCall action = ActionCall.For<ViewsForActionFilterTesterController>(x => x.AAction());
            token.Name = "something different";

            filter.Apply(action, bag).First().ShouldBeTheSameAs(token);
        }
    }


    public class FakeViewToken : BehaviorNode, IViewToken
    {
        public override BehaviorCategory Category { get { return BehaviorCategory.Output; } }

        public Type ViewModelType { get; set; }

        public string Folder { get; set; }

        public string Name { get; set; }

        public BehaviorNode ToBehavioralNode()
        {
            return this;
        }

        public Type ViewType { get; set;}

        protected override ObjectDef buildObjectDef()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name ?? string.Empty;
        }
    }

    public class AAction
    {

    }

    public class SomeOtherView
    {
        
    }

    namespace SubNamesapce
    {
        public class AAction
        {
            
        }
    }

    public class ViewsForActionFilterTesterController
    {
        public ViewModel1 AAction()
        {
            return null;
        }

        public ViewModel1 B()
        {
            return null;
        }

        public ViewModel1 C()
        {
            return null;
        }

        public ViewModel1 D()
        {
            return null;
        }

        public ViewModel1 E()
        {
            return null;
        }
    }
}