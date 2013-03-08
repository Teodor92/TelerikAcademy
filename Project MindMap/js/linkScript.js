var names = new Array();
var links = new Array();
names[0] = "preface";
links[0] = "mindmap-preview.html?image=team_58_chapter_19_DataStructs.jpg&title=Preface";


function SetLinks () {
	for (var i = names.length - 1; i >= 0; i--) {
		var element = document.getElementsByName(names[i]);
		for (var j = element.length - 1; j >= 0; j--) {
			element[j].href= links[i]};
		}
	};
