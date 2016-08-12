Array.prototype.shuffle = function () {
            var self = this,
                n = self.length,
                i,
                j,
                tmp;

            for (i = n - 1; i > 0; i -= 1) {
                j = Math.floor(Math.random() * (i + 1));
                tmp = self[i];
                self[i] = self[j];
                self[j] = tmp;
            }
            return self;
        };
 
    function Random(range) {
        range = range || 1;
        return (Math.round(Math.random() * range));
    }
