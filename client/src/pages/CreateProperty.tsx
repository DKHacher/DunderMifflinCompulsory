import createProperty from "../components/createProperty.tsx";

function CreateProperty () {
    return (
        <div>
            <div>
                Property Name
                <input type="text" id="Pname"></input>
            </div>
            <button onClick={test}>Reload</button>
        </div>
    )
}

export default CreateProperty

function test() {
    if (document.getElementById("Pname") != null) {
        // @ts-ignore
        createProperty(document.getElementById("Pname").value)
    }
}