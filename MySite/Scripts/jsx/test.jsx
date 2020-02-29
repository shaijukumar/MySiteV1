class HelloWorld extends React.Component {
    render() {
        console.log("Hello World React JS! from react");
        return (
            <div>
                <h1>Hello World React JS 12321!</h1>
            </div>
        )
    }
}

ReactDOM.render(
    <HelloWorld />,
    document.getElementById('myContainer'));
