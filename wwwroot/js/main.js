import { InlineEditor, AccessibilityHelp, AutoLink, Autosave, Bold, Essentials, Italic, Link, Paragraph, SelectAll, Undo, SpecialCharacters } from 'ckeditor5';

const editorConfig = {
	toolbar: {
		items: ['undo', 'redo', '|', 'bold', 'italic', '|', 'specialcharacters', '|', 'link'],
		shouldNotGroupWhenFull: false
	},
om	plugins: [AccessibilityHelp, AutoLink, Autosave, Bold, Essentials, Italic, Link, Paragraph, SelectAll, Undo, 
		SpecialCharacters, SpecialCharactersTranscription],					// SpecialCharactersEmoji, 
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
	placeholder: 'Вставьте сюда транскрипцию слова'
};
function SpecialCharactersTranscription(editor) {
	editor.plugins.get('SpecialCharacters').addItems('Transcription', [
		{ title: 'короткий [а]', character: 'ʌ' },
		{ title: '[а]', character: 'ɑ' },
		{ title: 'длинный [аа]', character: 'ɑ:' },
		{ title: 'звук между [а] и [э]', character: 'æ' },
		{ title: 'близкий к [э]', character: 'e' },
		{ title: 'безударный и короткий [э]', character: 'ə' },
		{ title: 'глухой звук [э], который не всегда произносят', character: '(ə)' },
		{ title: 'звук между [о] и [ё], как в «мёд»', character: 'ɜ:' },
		{ title: 'звук между [и] и [е]', character: 'i' },
		{ title: 'длинный [ии]', character: 'i:' },
		{ title: 'звук между [о] и [а]', character: 'ɒ' },
		{ title: 'долгий [оо]', character: 'ɔ:' },
		{ title: 'короткий [у]', character: 'ʊ' },
		{ title: 'звук [у]', character: 'u' },
		{ title: 'длинный [уу]', character: 'u:' },
		{ title: 'близкий к [б]', character: 'b' },
		{ title: 'близкий к [д]', character: 'd' },
		{ title: 'близкий к [ф]', character: 'f' },
		{ title: 'близкий к [г]', character: 'g' },
		{ title: 'близкий к [х]', character: 'h' },
		{ title: '[дж]', character: 'ʤ' },
		{ title: 'близкий к [к]', character: 'k' },
		{ title: 'немного мягче [л]', character: 'l' },
		{ title: 'близкий к [м]', character: 'm' },
		{ title: 'близкий к [н]', character: 'n' },
		{ title: 'носовой [н]', character: 'ŋ' },
		{ title: 'близкий к [п]', character: 'p' },
		{ title: 'звучит мягче [р]', character: 'r' },
		{ title: 'близкий к [с]', character: 's' },
		{ title: 'близкий к [т]', character: 't' },
		{ title: 'близкий к [в]', character: 'v' },
		{ title: 'звук между [у] и [в]', character: 'w' },
		{ title: 'звук между [й] и [и]', character: 'j' },
		{ title: 'близкий к [з]', character: 'z' },
		{ title: 'межзубный звук: в BrE ближе к [в], в AmE – к [д]', character: 'ð' },
		{ title: 'межзубный звук: в BrE ближе к [ф], в AmE – к [т]', character: 'θ' },
		{ title: 'близкий к [ч]', character: 'ʧ' },
		{ title: 'звук между [ш] и [щ]', character: 'ʃ' },
		{ title: 'немного мягче русского [ж]', character: 'ʒ' },
		{ title: 'ударение', character: '´' },
		{ title: 'понижение голоса', character: 'ˏ' },
	], { label: 'Transcription' });
}

/* SpecialCharactersEmoji, 
function SpecialCharactersEmoji(editor) {
	editor.plugins.get('SpecialCharacters').addItems('Emoji', [
		{ title: 'smiley face', character: '😊' },
		{ title: 'rocket', character: '🚀' },
		{ title: 'wind blowing face', character: '🌬️' },
		{ title: 'floppy disk', character: '💾' },
		{ title: 'heart', character: '❤️' }
	], { label: 'Emoticons' });
}
*/
InlineEditor.create(document.querySelector('#editor'), editorConfig);
