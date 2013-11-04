/// <reference path="class.js" />
/// <reference path="http-requester.js" />

var persisters = (function () {

	var MainPersister = Class.create({
		init: function (rootUrl) {
			this.rootUrl = rootUrl;
			this.song = new SongPresister(this.rootUrl);
			this.artist = new ArtistPresiter(this.rootUrl);
			this.album = new AlbumPresister(this.rootUrl);
		},
	});

	var SongPresister = Class.create({
	    init: function (rootUrl) {
	        this.rootUrl = rootUrl + "Song/"
	    },

	    getAllSongs: function (success, error) {
	        httpRequester.getJson(this.rootUrl, success, error);
	    },

	    getSingleSong: function (songId, succes, error) {
	        httpRequester.getJson(this.rootUrl + songId, succes, error);
	    },

	    addSong: function (data, sucess, error) {
	        httpRequester.postJson(this.rootUrl, data, sucess, error);
	    },

	    updateSong: function (updateId, data, success, error) {
	        httpRequester.putJson(this.baseUrl + updateId, data, success, error);
	    },

	    deleteSong: function (deleteId, success, error) {
	        httpRequester.deleteJson(this.rootUrl + deleteId, success, error);
	    }

	});

	var ArtistPresiter = Class.create({
	    init: function (rootUrl) {
	        this.rootUrl = rootUrl + "Artist/"
	    },

	    getAllArtists: function (success, error) {
	        httpRequester.getJson(this.rootUrl, success, error);
	    },

	    getSingleArtist: function (songId, succes, error) {
	        httpRequester.getJson(this.rootUrl + songId, succes, error);
	    },

	    addArtist: function (data, sucess, error) {
	        httpRequester.postJson(this.rootUrl, data, sucess, error);
	    },

	    updateArtist: function (updateId, data, success, error) {
	        httpRequester.putJson(this.baseUrl + updateId, data, success, error);
	    },

	    deleteArtist: function (deleteId, success, error) {
	        httpRequester.deleteJson(this.rootUrl + deleteId, success, error);
	    }
	});

	var AlbumPresister = Class.create({
	    init: function (rootUrl) {
	        this.rootUrl = rootUrl + "Album/"
	    },

	    getAllAlbums: function (success, error) {
	        httpRequester.getJson(this.rootUrl, success, error);
	    },

	    getSingleAlbum: function (songId, succes, error) {
	        httpRequester.getJson(this.rootUrl + songId, succes, error);
	    },

	    addAlbum: function (data, sucess, error) {
	        httpRequester.postJson(this.rootUrl, data, sucess, error);
	    },

	    updateAlbum: function (updateId, data, success, error) {
	        httpRequester.putJson(this.baseUrl + updateId, data, success, error);
	    },

	    deleteAlbum: function (deleteId, success, error) {
	        httpRequester.deleteJson(this.rootUrl + deleteId, success, error);
	    }
	});

	return {
		get: function (url) {
			return new MainPersister(url);
		}
	};
}());