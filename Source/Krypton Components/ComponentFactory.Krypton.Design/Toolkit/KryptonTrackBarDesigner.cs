﻿// *****************************************************************************
// 
//  © Component Factory Pty Ltd 2018. All rights reserved.
//	The software and associated documentation supplied hereunder are the 
//  proprietary information of Component Factory Pty Ltd, 13 Swallows Close, 
//  Mornington, Vic 3931, Australia and are supplied subject to licence terms.
// 
//  Version 4.7.0.0 	www.ComponentFactory.com
// *****************************************************************************

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ComponentFactory.Krypton.Toolkit
{
    internal class KryptonTrackBarDesigner : ControlDesigner
    {
        #region Instance Fields
        private KryptonTrackBar _trackBar;
        #endregion

        #region Public Overrides
        /// <summary>
        /// Initializes the designer with the specified component.
        /// </summary>
        /// <param name="component">The IComponent to associate the designer with.</param>
        public override void Initialize(IComponent component)
        {
            // Let base class do standard stuff
            base.Initialize(component);
            base.AutoResizeHandles = true;

            // Cast to correct type
            _trackBar = component as KryptonTrackBar;
        }

        /// <summary>
        /// Gets the selection rules that indicate the movement capabilities of a component.
        /// </summary>
        public override SelectionRules SelectionRules
        {
            get
            {
                if (!_trackBar.AutoSize)
                {
                    return SelectionRules.AllSizeable | SelectionRules.Moveable;
                }
                else
                {
                    if (_trackBar.Orientation == Orientation.Horizontal)
                    {
                        return SelectionRules.RightSizeable | SelectionRules.LeftSizeable | SelectionRules.Moveable;
                    }
                    else
                    {
                        return SelectionRules.TopSizeable | SelectionRules.BottomSizeable | SelectionRules.Moveable;
                    }
                }
            }
        }

        /// <summary>
        ///  Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // Create a collection of action lists
                DesignerActionListCollection actionLists = new DesignerActionListCollection
                {

                    // Add the button specific list
                    new KryptonTrackBarActionList(this)
                };

                return actionLists;
            }
        }
        #endregion
    }
}
