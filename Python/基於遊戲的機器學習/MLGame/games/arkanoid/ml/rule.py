"""
The template of the main script of the machine learning process
"""
import random


class MLPlay:
    def __init__(self):
        """
        Constructor
        """
        self.ball_served = False
        self.previous_ball = (0, 0)
        self.rand = 75

    def update(self, scene_info):
        """
        Generate the command according to the received `scene_info`.
        """
        # Make the caller to invoke `reset()` for the next round.
        if scene_info["status"] == "GAME_OVER" or scene_info["status"] == "GAME_PASS":
            return "RESET"
        if not self.ball_served:
            p = scene_info["platform"][0]
            if p == self.rand:
                self.ball_served = True
                return "SERVE_TO_LEFT" if random.randint(0, 1) else "SERVE_TO_RIGHT"
            command = "MOVE_LEFT" if p > self.rand else "MOVE_RIGHT"
        else:
            platform = scene_info["platform"][0]
            ball_x = scene_info["ball"][0]
            ball_y = scene_info["ball"][1]
            ball_speed_x = scene_info["ball"][0] - self.previous_ball[0]
            ball_speed_y = scene_info["ball"][1] - self.previous_ball[1]
            slope = ball_speed_y / ball_speed_x if ball_speed_x != 0 else 0
            px = ball_x + (395 - ball_y) / slope if slope != 0 else ball_x
            while px < 0 or px > 195:
                if px < 0:
                    px *= -1
                elif px > 195:
                    px = 195 - (px - 195)
            if 20 <= px <= 180:
                px -= 20
            elif 0 <= px <= 20:
                px = 0
            elif 180 <= px <= 195:
                px = 160
            if ball_y < 280:
                px = 80
            else:
                if ball_speed_y < 0 and ball_y > 310:
                    px = ball_x
            if px - 5 <= platform <= px + 5:
                command = "NONE"
            else:
                command = "MOVE_RIGHT" if platform < px else "MOVE_LEFT"
            self.previous_ball = scene_info["ball"]

        return command

    def reset(self):
        """
        Reset the status
        """
        self.ball_served = False
        self.previous_ball = (0, 0)
        self.rand = random.randint(0, 16) * 5

