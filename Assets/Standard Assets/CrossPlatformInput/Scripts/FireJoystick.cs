using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;
namespace UnityStandardAssets.CrossPlatformInput
{
    public class FireJoystick : Joystick
    {
        
        public string ButtonName = "";

        private CrossPlatformInputManager.VirtualButton mVirtualButton;
        public override void OnEnable()
        {
            base.OnEnable();
            mVirtualButton = new CrossPlatformInputManager.VirtualButton(ButtonName);
            CrossPlatformInputManager.RegisterVirtualButton(mVirtualButton);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            mVirtualButton.Remove();
        }

        public override void OnPointerUp(PointerEventData data)
        {
            CrossPlatformInputManager.SetButtonUp(ButtonName);
            base.OnPointerUp(data);
        }


        public override void OnPointerDown(PointerEventData data)
        {
            CrossPlatformInputManager.SetButtonDown(ButtonName);
        }

    }
}
