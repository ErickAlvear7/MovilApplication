﻿

namespace MovilApplication.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViewModels;
    public class InstanceLocator
    {
        #region Properties

        public MainViewModel Main { get; set; }

        #endregion


        #region Contructor

        public InstanceLocator()

        {

            this.Main = new MainViewModel();

        }

        #endregion
    }
}
