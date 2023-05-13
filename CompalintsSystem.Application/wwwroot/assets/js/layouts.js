'use strict';

// isSmallScreen

$('#helpers-isSmallScreen').click(function () {
  alert(window.Helpers.isSmallScreen());
});

// isLayout1

$('#helpers-isLayout1').click(function () {
  alert(window.Helpers.isLayout1());
});

// isCollapsed

$('#helpers-isCollapsed').click(function () {
  alert(window.Helpers.isCollapsed());
});

// isFixed

$('#helpers-isFixed').click(function () {
  alert(window.Helpers.isFixed());
});

// isOffcanvas

$('#helpers-isOffcanvas').click(function () {
  alert(window.Helpers.isOffcanvas());
});

// isNavbarFixed

$('#helpers-isNavbarFixed').click(function () {
  alert(window.Helpers.isNavbarFixed());
});

// isFooterFixed

$('#helpers-isFooterFixed').click(function () {
  alert(window.Helpers.isFooterFixed());
});

// isFlipped

$('#helpers-isFlipped').click(function () {
  alert(window.Helpers.isFlipped());
});

// setCollapsed

$('#helpers-setCollapsed-false-true').click(function () {
  window.Helpers.setCollapsed(false, true);
});
$('#helpers-setCollapsed-true-true').click(function () {
  window.Helpers.setCollapsed(true, true);
});
$('#helpers-setCollapsed-false-false').click(function () {
  window.Helpers.setCollapsed(false, false);
});
$('#helpers-setCollapsed-true-false').click(function () {
  window.Helpers.setCollapsed(true, false);
});

// toggleCollapsed

$('#helpers-toggleCollapsed-true').click(function () {
  window.Helpers.toggleCollapsed(true);
});
$('#helpers-toggleCollapsed-false').click(function () {
  window.Helpers.toggleCollapsed(false);
});

// setPosition

$('#helpers-setPosition-collapse').click(function () {
  window.Helpers.setCollapsed(true, false);
});
$('#helpers-setPosition-false-false').click(function () {
  window.Helpers.setPosition(false, false);
});
$('#helpers-setPosition-true-false').click(function () {
  window.Helpers.setPosition(true, false);
});
$('#helpers-setPosition-false-true').click(function () {
  window.Helpers.setPosition(false, true);
});
$('#helpers-setPosition-true-true').click(function () {
  window.Helpers.setPosition(true, true);
});

// setNavbarFixed

$('#helpers-setNavbarFixed-reset').click(function () {
  window.Helpers.setPosition(false, false);
});
$('#helpers-setNavbarFixed-true').click(function () {
  window.Helpers.setNavbarFixed(true);
});
$('#helpers-setNavbarFixed-false').click(function () {
  window.Helpers.setNavbarFixed(false);
});

// setFooterFixed

$('#helpers-setFooterFixed-true').click(function () {
  window.Helpers.setFooterFixed(true);
});
$('#helpers-setFooterFixed-false').click(function () {
  window.Helpers.setFooterFixed(false);
});

// setFlipped

$('#helpers-setFlipped-true').click(function () {
  window.Helpers.setFlipped(true);
});
$('#helpers-setFlipped-false').click(function () {
  window.Helpers.setFlipped(false);
});
