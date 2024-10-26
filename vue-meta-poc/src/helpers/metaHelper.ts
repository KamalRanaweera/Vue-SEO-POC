export interface MetaInfo {
    name: string | undefined,
    property: string | undefined,
    content: string
}

export const updateMeta = (title: string, componentMetaInfo: MetaInfo[], cleanAllOldMeta: boolean) =>{

    if(title){
        document.title = title;
    }

    let oldMetaArray = Array.from(document.getElementsByTagName('meta'));
    if(cleanAllOldMeta){
        oldMetaArray.forEach(x => x.remove());
        oldMetaArray =  [];
    }

    componentMetaInfo.forEach(metaInfo => {
        const newMetaElement = document.createElement('meta')
        if(metaInfo.name) {
            oldMetaArray.length > 0 && oldMetaArray.find(x => x.name === metaInfo.name)?.remove();
            newMetaElement.name = metaInfo.name;
        }

        if(metaInfo.property) {
            oldMetaArray.length > 0 && oldMetaArray.find(x => x.getAttribute('property') === metaInfo.property)?.remove();
            newMetaElement.setAttribute('property', metaInfo.property);
        } 
        
        newMetaElement.content = metaInfo.content!;
        document.head.appendChild(newMetaElement)
    });
}