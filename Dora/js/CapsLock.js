/*

CapsLock.js

An object allowing the status of the caps lock key to be determined

Created by Stephen Morley - http://code.stephenmorley.org/ - and released under
the terms of the CC0 1.0 Universal legal code:

http://creativecommons.org/publicdomain/zero/1.0/legalcode

*/

// create the CapsLock object
var CapsLock = (function(){

  // initialise the status of the caps lock key
  var capsLock = false;

  // initialise the list of listeners
  //  var listeners = [];

  // store whether we are running on a Mac
  //var isMac = /Mac/.test(navigator.platform);

  // Returns whether caps lock currently appears to be on.
  function isOn(){
    return capsLock;
  }

  /* Adds a listener. When a change is detected in the status of the caps lock
  * key the listener will be called, with a parameter of true if caps lock is
  * now on and false if caps lock is now off. The parameter is:
  *
  * listener - the listener
  */

  document.addEventListener('keydown', function(event) {
    /* See https://developer.mozilla.org/en-US/docs/Web/API/KeyboardEvent/getModifierState
    This function is supported in Firefox & MS Edge, webkit browsers
    will be supported (soon) */
    var caps = event.getModifierState && event.getModifierState('CapsLock');
    capsLock = caps; // true when you press the keyboard CapsLock key
  });

  // return the public API
  return {
    isOn        : isOn,
    //addListener : addListener
  };

})();
