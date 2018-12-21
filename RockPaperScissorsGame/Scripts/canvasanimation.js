CanvasRenderingContext2D.prototype.fillTextAnimation = function (text, color, x1, y1, a1, x2, y2, a2, frame) {
    var animationObj = {
        type: "fillText",
        text: text,
        color: color,
        x: x1, y: y1, a: a1,
        dx: (x2 - x1) / frame,
        dy: (y2 - y1) / frame,
        da: (a2 - a1) / frame,
        frame: frame,
        nowFrame: 0
    };

    if (!this.animationList)
        this.animationList = [];

    this.animationList.push(animationObj);
};

CanvasRenderingContext2D.prototype.animationDrawLoop = function () {
    if (this.animationList) {
        for (var i = 0; i < this.animationList.length; i++) {
            var animationObj = this.animationList[i];

            switch (animationObj.type) {
                case "fillText":
                    this.globalAlpha = animationObj.a;
                    this.fillStyle = animationObj.color;
                    this.fillText(animationObj.text, animationObj.x, animationObj.y);
                    this.globalAlpha = 1;
                    break;
            }

            animationObj.x += animationObj.dx;
            animationObj.y += animationObj.dy;
            animationObj.a += animationObj.da;
            animationObj.nowFrame += 1;

            if (animationObj.nowFrame >= animationObj.frame) {
                this.animationList.splice(i, 1);
                i--;
            }
        }
    }
};