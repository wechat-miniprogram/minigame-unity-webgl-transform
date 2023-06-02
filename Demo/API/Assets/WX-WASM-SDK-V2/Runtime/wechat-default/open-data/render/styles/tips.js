export default function getStyle(data) {
    return {
        container: {
            flexDirection: 'row',
            width: data.width,
            height: data.height,
            justifyContent: 'center',
            alignItems: 'center',
        },
        tips: {
            color: '#000000',
            width: data.width,
            height: 50,
            fontSize: 50,
            textAlign: 'center',
        },
    };
}
