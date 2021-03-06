// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.ComponentModel;
using Microsoft.Toolkit.Forms.UI.XamlHost;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
using windows = Windows;

namespace Microsoft.Toolkit.Forms.UI.Controls
{
    /// <summary>
    /// Forms-enabled wrapper for <see cref="windows.UI.Xaml.Controls.SwapChainPanel"/>
    /// </summary>
#pragma warning disable CA1812 // Avoid uninstantiated internal classes
    internal class SwapChainPanel : WindowsXamlHostBase
#pragma warning restore CA1812 // Avoid uninstantiated internal classes
    {
        internal windows.UI.Xaml.Controls.SwapChainPanel UwpControl => GetUwpInternalObject() as windows.UI.Xaml.Controls.SwapChainPanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwapChainPanel"/> class, a
        /// Forms-enabled wrapper for <see cref="windows.UI.Xaml.Controls.SwapChainPanel"/>
        /// </summary>
        public SwapChainPanel()
            : this(typeof(windows.UI.Xaml.Controls.SwapChainPanel).FullName)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SwapChainPanel"/> class, a
        /// Forms-enabled wrapper for <see cref="windows.UI.Xaml.Controls.SwapChainPanel"/>.
        /// Intended for internal framework use only.
        /// </summary>
        public SwapChainPanel(string typeName)
            : base(typeName)
        {
            // Return immediately if control is instantiated by the Visual Studio Designer
            // https://stackoverflow.com/questions/1166226/detecting-design-mode-from-a-controls-constructor
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            if (UwpControl != null)
            {
                UwpControl.CompositionScaleChanged += OnCompositionScaleChanged;
            }
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CreateCoreIndependentInputSource"/>
        /// </summary>
        /// <returns>CoreIndependentInputSource</returns>
        public CoreIndependentInputSource CreateCoreIndependentInputSource(CoreInputDeviceTypes deviceTypes) => UwpControl.CreateCoreIndependentInputSource((windows.UI.Core.CoreInputDeviceTypes)deviceTypes);

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleX"/>
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float CompositionScaleX
        {
            get => UwpControl.CompositionScaleX;
        }

        /// <summary>
        /// Gets <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleY"/>
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float CompositionScaleY
        {
            get => UwpControl.CompositionScaleY;
        }

        /// <summary>
        /// <see cref="windows.UI.Xaml.Controls.SwapChainPanel.CompositionScaleChanged"/>
        /// </summary>
        public event EventHandler<object> CompositionScaleChanged = (sender, args) => { };

        private void OnCompositionScaleChanged(windows.UI.Xaml.Controls.SwapChainPanel sender, object args)
        {
            this.CompositionScaleChanged?.Invoke(this, args);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                if (UwpControl != null)
                {
                    UwpControl.CompositionScaleChanged -= OnCompositionScaleChanged;
                }
            }
        }
    }
}