function solve() {
  return function (selector) {
    if (typeof (selector) === 'string') {
      selector = document.getElementById(selector);
      if (!selector) {
        throw new Error();
      }
    }
    else if (!(selector instanceof HTMLElement)) {
      throw new Error();
    }

    var buttons = document.querySelectorAll('.button'),
      len = buttons.length, i;

    for (i = 0; i < len; i += 1) {
      buttons[i].innerHTML = 'hide';
    }

    function clickEvent(ev) {
      var target = ev.target,
        nextSibling = target.nextElementSibling;

      if (target.className === 'button') {
        while (nextSibling) {
          if (nextSibling.className === 'content') {
            
            if (nextSibling.style.display === 'none') {
              nextSibling.style.display = '';
              target.innerHTML = 'hide';
            } else {
              nextSibling.style.display = 'none';
              target.innerHTML = 'show';
            }
            break;
          } else if (nextSibling.className === 'button') {
            break;
          }

          nextSibling = nextSibling.nextElementSibling;
        }
      }
    }

    selector.addEventListener('click', clickEvent);
  };
}