angular.module('ContactMgr', [
    'contacts.main',
    'contacts.resource',
    'contacts.resource.category',
    'contacts.resource.contact',
    'contacts.resource.string'])

.filter('telephone', function () {
    return function (s) {
        if (s.match(/^[0-9]{10}$/)) {
            var sb = ['(', s.slice(0, 3), ') ', s.slice(3, 6), '-', s.slice(6, 10)]
            return sb.join('');
        } else {
            return s || '';
        }
    }
});