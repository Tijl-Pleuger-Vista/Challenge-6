#!./venv/bin/python3
#imports
from flask import Flask, render_template, redirect, url_for, request, jsonify
app = Flask(__name__)

@app.route("/")
def home():
    user_ip = request.headers.get('X-Forwarded-For')
    user_os = request.headers.get('Sec-CH-UA-Platform')
    user_agent = request.headers.get('User-Agent')
    return render_template("home.html", user_ip=user_ip, user_agent=user_agent, user_os=user_os)

@app.route("/docs")
def docs():
    return render_template("docs.html")

@app.route("/help")
def help():
    return render_template("help.html")

@app.route("/about")
def about():
    return render_template("about.html")

if __name__ == "__main__":
    app.run(debug=False)
