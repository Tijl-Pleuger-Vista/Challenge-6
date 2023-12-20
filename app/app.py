#imports
from flask import Flask, render_template, redirect, url_for, request, jsonify
app = Flask(__name__)

@app.route("/")
def home():
    user_ip = request.environ.get('HTTP_X_REAL_IP', request.remote_addr)
    user_agent = request.headers.get('User-Agent')
    return render_template("home.html", user_ip=user_ip, user_agent=user_agent)

# @app.route("/data")
# def var():
#     user_ip = "127.0.0.1"
#     return render_template("data.html", user_ip=user_ip)

# @app.route("/download")
# def ifelse():
#     os = "windows"
#     return render_template("download.html", os=os)

# @app.route("/docs")
# def default():
#     return render_template("docs.html")

# @app.route("/help")
# def default():
#     return render_template("docs.html")

# @app.route("/about")
# def default():
#     return render_template("about.html")

if __name__ == "__main__":
    app.run(debug=False)
