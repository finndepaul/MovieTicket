window.initializeFroalaEditor = (editorId, dotNetHelper) => {
    new FroalaEditor(`#${editorId}`, {
        events: {
            'contentChanged': function () {
                dotNetHelper.invokeMethodAsync('UpdateContent', this.html.get());
            }
        }
    });
};
