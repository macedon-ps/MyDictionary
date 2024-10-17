import { InlineEditor, AccessibilityHelp, AutoLink, Autosave, Bold, Essentials, Italic, Link, Paragraph, SelectAll, Undo, SpecialCharacters } from 'ckeditor5';

const editorConfig = {
	toolbar: {
		items: ['undo', 'redo', '|', 'bold', 'italic', '|', 'specialcharacters', '|', 'link'],
		shouldNotGroupWhenFull: false
	},
	plugins: [AccessibilityHelp, AutoLink, Autosave, Bold, Essentials, Italic, Link, Paragraph, SelectAll, Undo, SpecialCharacters, SpecialCharactersEmoji],
	initialData:
		'<h2>Hello in CKEditor 5!</h2>\n<p>\n    You\'ve successfully created a CKEditor 5 project. This powerful text editor will enhance your application, enabling rich text editing\n    capabilities that are customizable and easy to use.\n</p>\n<h3>What\'s next?</h3>\n',
	link: {
		addTargetToExternalLinks: true,
		defaultProtocol: 'https://',
		decorators: {
			toggleDownloadable: {
				mode: 'manual',
				label: 'Downloadable',
				attributes: {
					download: 'file'
				}
			}
		}
	},
	placeholder: 'Type or paste your content here!'
};


function SpecialCharactersEmoji(editor) {
	editor.plugins.get('SpecialCharacters').addItems('Emoji', [
		{ title: 'smiley face', character: '😊' },
		{ title: 'rocket', character: '🚀' },
		{ title: 'wind blowing face', character: '🌬️' },
		{ title: 'floppy disk', character: '💾' },
		{ title: 'heart', character: '❤️' }
	], { label: 'Emoticons' });
}

InlineEditor.create(document.querySelector('#editor'), editorConfig);
